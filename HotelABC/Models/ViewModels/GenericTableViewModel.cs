using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelABC.Models.ViewModels;

public class GenericTableViewModel<T>
{
    public string Title { get; set; }
    public string[] ColumnNames { get; set; }
}