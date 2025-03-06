using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelABC.Models.ViewModels;

public class WithDropDownsViewModel : BaseViewModel
{
    public Dictionary< string, IEnumerable<SelectListItem> > Dropdowns { get; set; } = new();
}