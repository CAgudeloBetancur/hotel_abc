using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HotelABC.Controllers.Contracts;

public interface IGenericController<TEntity, TCreateViewModel, TEditViewModel> 
    where TEntity : class
    where TCreateViewModel : class
    where TEditViewModel : class
{
    IActionResult Index();
    Task<IActionResult> GetData();
    IActionResult Create();
    Task<IActionResult> Create(TCreateViewModel model);
    Task<IActionResult> Edit(Guid id);
    Task<IActionResult> Edit(Guid id, TEditViewModel model);
    Task<IActionResult> Delete(Guid id);
}