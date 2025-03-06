using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelABC.Data;
using HotelABC.Models.Entities;
using HotelABC.Utils;
using HotelABC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HotelABC.Controllers.Contracts;
using HotelABC.Models.ViewModels.Entities.ApplicationUser;

namespace HotelABC.Controllers.Entities;

[Route("[controller]")]
public class ApplicationUserController 
    : Controller, IGenericController<ApplicationUser, ApplicationUserCreateViewModel, ApplicationUserEditViewModel>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ApplicationUserController(UserManager<ApplicationUser> userManager) 
    { 
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var viewModel = new GenericTableViewModel<ApplicationUser>
        {
            Title = typeof(ApplicationUser).Name,
            ColumnNames = TableConfig.GetColumnsFor<ApplicationUser>(),
        };

        return View("~/Views/Generic/Index.cshtml", viewModel);
    }

    [HttpPost("GetData")]
    public async Task<IActionResult> GetData()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
        var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "10");
        var searchValue = Request.Form["search[value]"].FirstOrDefault();

        var orderColumnIndex = Request.Form["order[0][column]"].FirstOrDefault();
        var orderDirection = Request.Form["order[0][dir]"].FirstOrDefault();

        // Obtener la lista de usuarios
        var usersQuery = _userManager.Users.AsQueryable();

        // Filtrar
        if (!string.IsNullOrEmpty(searchValue))
        {
            usersQuery = usersQuery
                .Where(
                    u => u.FirstName.Contains(searchValue) || 
                    u.Email.Contains(searchValue) ||
                    u.LastName.Contains(searchValue) ||
                    u.DocumentValue.Contains(searchValue)
                    );
        }

        if (!string.IsNullOrEmpty(orderColumnIndex) && int.TryParse(orderColumnIndex, out int columnIndex))
        {
            // Obtener las columnas válidas para ApplicationUser
            var properties = TableConfig.GetColumnsFor<ApplicationUser>();

            if (columnIndex >= 0 && columnIndex < properties.Length)
            {
                string columnName = properties[columnIndex];

                var param = Expression.Parameter(typeof(ApplicationUser), "x");
                var property = Expression.Property(param, columnName);
                var lambda = Expression.Lambda(property, param);

                string methodName = orderDirection == "desc" ? "OrderByDescending" : "OrderBy";

                var orderMethod = typeof(Queryable)
                    .GetMethods()
                    .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(ApplicationUser), property.Type);

                usersQuery = (IQueryable<ApplicationUser>)orderMethod.Invoke(null, new object[] { usersQuery, lambda })!;
            }
        }

        // Paginación
        var totalRecords = await usersQuery.CountAsync();

        var users = await usersQuery.Skip(start).Take(length).ToListAsync();

        return Ok(new
        {
            draw = draw,
            recordsFiltered = totalRecords,
            recordsTotal = totalRecords,
            data = users.Select(u => new 
            {
                u.Id,
                u.FirstName,
                u.LastName,
                u.Email,
                u.PhoneNumber,
                u.DocumentValue
            })
        });
    }

    public IActionResult Create()
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Create(ApplicationUserCreateViewModel model)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Edit(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Edit(Guid id, ApplicationUserEditViewModel model)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}