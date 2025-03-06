using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelABC.Models.ViewModels;

public abstract class BaseViewModel
{
    public Guid Id { get; set; }
}