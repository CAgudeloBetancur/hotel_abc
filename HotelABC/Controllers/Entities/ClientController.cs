using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelABC.Data;
using HotelABC.Data.Contracts;
using HotelABC.Models;
using HotelABC.Models.Entities;
using HotelABC.Models.Parameters;
using HotelABC.Models.ViewModels.Entities.Client;
using HotelABC.Repositories.Contracts;
using HotelABC.Repositories.Implementations.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace HotelABC.Controllers;

[Route("[controller]")]
public class ClientController 
    : GenericController<Client, ClientCreateViewModel, ClientEditViewModel, ClientRepository>
{
    public ClientController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

    protected override void PrepareCreateViewModel(ClientCreateViewModel viewModel)
    {
        
        viewModel.Dropdowns = new()
        {
            ["Categoria"] = new List<SelectListItem>
            {
                new SelectListItem { Text = "Opción 1", Value = "1" },
                new SelectListItem { Text = "Opción 2", Value = "2" }
            },
            ["Estado"] = new List<SelectListItem>
            {
                new SelectListItem { Text = "Activo", Value = "A" },
                new SelectListItem { Text = "Inactivo", Value = "I" }
            }
        };
    }
}