using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelABC.Models.ViewModels.Parameters;

public abstract class ParameterBaseViewModel : BaseViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
}