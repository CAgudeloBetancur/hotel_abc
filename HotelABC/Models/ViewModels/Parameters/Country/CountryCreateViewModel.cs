using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelABC.Models.ViewModels.Parameters.Country;

public class CountryCreateViewModel : ParameterBaseViewModel
{
    public string IsoCode { get; set; }
}