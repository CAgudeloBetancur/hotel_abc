using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelABC.Data;
using HotelABC.Utils;
using HotelABC.Models.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HotelABC.Controllers.Contracts;
using Microsoft.EntityFrameworkCore;
using HotelABC.Repositories.Contracts;
using HotelABC.Data.Contracts;
using AutoMapper;
using System.Reflection;

namespace HotelABC.Controllers;

[Route("[controller]")]
public abstract class GenericController<TEntity, TCreateViewModel, TEditViewModel, TRepository> 
    : Controller, IGenericController<TEntity, TCreateViewModel, TEditViewModel>
    where TEntity : class
    where TCreateViewModel : class
    where TEditViewModel : class
    where TRepository : class, IGenericRepository<TEntity>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenericController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        // _context = context;
    }

    // | -- IGenericController

    [HttpGet]
    public IActionResult Index()
    {
        var viewModel = new GenericTableViewModel<TEntity>
        {
            Title = typeof(TEntity).Name,
            ColumnNames = TableConfig.GetColumnsFor<TEntity>(),
        };

        return View("~/Views/Generic/Index.cshtml", viewModel);
    }

    [HttpPost("GetData")]
    public async Task<IActionResult> GetData () 
    {
        // Datos que envia datatables
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Request.Form["start"].FirstOrDefault();
        var length = Request.Form["length"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();

        // Datos ordenamiento
        var orderColumnIndex = Request.Form["order[0][column]"].FirstOrDefault();
        var orderDirection = Request.Form["order[0][dir]"].FirstOrDefault();

        // Casting de paginacion
        int pageSize = length != null ? Convert.ToInt32(length) : 10;
        int skip = start != null ? Convert.ToInt32(start) : 0;

        // Consulta
        var query = _unitOfWork.Repository<TRepository, TEntity>().GetAll().AsQueryable();

        // Filtrar por campo de busqueda
        if(!string.IsNullOrEmpty(searchValue))
        {
            var properties = typeof(TEntity)
                .GetProperties()
                .Where( p => p.PropertyType == typeof(string) );

            Expression<Func<TEntity, bool>> filterExpression = null;
            
            foreach(var prop in properties) 
            {
                var param = Expression.Parameter(typeof(TEntity), "x");
                var propertyAccess = Expression.Property(param, prop);
                var searchExpression = Expression.Constant(searchValue);
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var containsCall = Expression.Call(propertyAccess, containsMethod, searchExpression);

                var lambda = Expression.Lambda<Func<TEntity, bool>>(containsCall, param);

                if(filterExpression == null)
                {
                    filterExpression = lambda;
                }
                else
                {
                    filterExpression = Expression
                        .Lambda<Func<TEntity, bool>>(
                            Expression.OrElse(
                                filterExpression.Body, 
                                Expression.Invoke( lambda, filterExpression.Parameters)
                                ),
                            filterExpression.Parameters
                            );
                }

            }
            
            if(filterExpression != null) query = query.Where(filterExpression);
        }

        // Ordenamiento por columna

        if(!string.IsNullOrEmpty(orderColumnIndex) && int.TryParse(orderColumnIndex, out int columnIndex)) 
        {
            var properties = TableConfig.GetColumnsFor<TEntity>();

            if(columnIndex >= 0 && columnIndex < properties.Length)
            {
                string columnName = properties[columnIndex];

                var param = Expression.Parameter(typeof(TEntity), "x");
                var property = Expression.Property(param, columnName);
                var lambda = Expression.Lambda(property, param);

                string methodName = orderDirection == "desc" ? "OrderByDescending" : "OrderBy";

                var orderMethod = typeof(Queryable)
                    .GetMethods()
                    .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(TEntity), property.Type);

                query = (IQueryable<TEntity>)orderMethod.Invoke(null, new object[] { query, lambda })!;
            }
        }

        // Total de registros
        int totalRecords = await query.CountAsync();

        // Consulta paginada
        var data = await query.Skip(skip).Take(pageSize).ToListAsync();

        // Respuesta
        return Ok(
            new {
                draw = draw,
                recordsFiltered = totalRecords,
                recordsTotal = totalRecords,
                data = data
            }
        );
    }

    [HttpGet("Create")]
    public virtual IActionResult Create() 
    {
        var model = Activator.CreateInstance<TCreateViewModel>();
        PrepareCreateViewModel(model);
        ViewBag.IsEdit = false;
        return PartialView("~/Views/Generic/_GenericModal.cshtml", model);
    }

    [HttpPost("Create")]
    public async virtual Task<IActionResult> Create(TCreateViewModel model) 
    {
        if(!ModelState.IsValid) 
        {
            PrepareCreateViewModel(model);
            ViewBag.IsEdit = false;
            return PartialView("~/Views/Generic/_GenericModal.cshtml", model);
        }

        var entity = MapToEntity(model);
        
        await _unitOfWork.Repository<TRepository, TEntity>().AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return Json(new { success = true, redirectUrl = Url.Action("Index") });
    }

    [HttpGet("Edit/{id}")]
    public async virtual Task<IActionResult> Edit(Guid id)
    {
        var entity = await _unitOfWork.Repository<TRepository, TEntity>().GetByIdAsync(id);
        
        if(entity == null) return NotFound();

        var model = MapToEditViewModel(entity);

        PrepareEditViewModel(model);

        ViewBag.IsEdit = true;

        return PartialView("~/Views/Generic/_GenericModal.cshtml", model);
    }

    [HttpPost("Edit/{id}")]
    public async virtual Task<IActionResult> Edit(Guid id, TEditViewModel model) 
    {
        if(!ModelState.IsValid) 
        {
            PrepareEditViewModel(model);
            ViewBag.IsEdit = true;
            return PartialView("~/Views/Generic/_GenericModal.cshtml", model);
        }

        var entity = MapToEntity(model);
        
        await _unitOfWork.Repository<TRepository, TEntity>().UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        return Json(new { success = true, redirectUrl = Url.Action("Index") });
    }

    [HttpDelete("Delete/{id}")]
    public async virtual Task<IActionResult> Delete(Guid id) 
    {
        var entity = await _unitOfWork.Repository<TRepository, TEntity>().GetByIdAsync(id);
        
        if(entity == null) 
        {
            return Json(new {success = false, message = "No element found with this id"});
        }

        await _unitOfWork.Repository<TRepository, TEntity>().DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return Json(new {success = true, message = "Element deleted", redirectUrl = Url.Action("Index")});
    }

    // -- |     
    // | -- PrepareViewModels default implementation

    protected virtual void PrepareCreateViewModel(TCreateViewModel model) { }
    protected virtual void PrepareEditViewModel(TEditViewModel model) { }

    // -- |
    // | -- Mapping

    protected virtual TEntity MapToEntity(TCreateViewModel model) 
    {
        return _mapper.Map<TEntity>(model);
    }

    protected virtual TEntity MapToEntity(TEditViewModel model)
    {
        return _mapper.Map<TEntity>(model);
    }
    protected virtual TEditViewModel MapToEditViewModel(TEntity entity) 
    {
        return _mapper.Map<TEditViewModel>(entity);
    }

    // -- |
}