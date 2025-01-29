using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Complements;

namespace HotelABC.Models.Parameters
{
    public class ConsumptionType : BaseParameter
    {
        public decimal BasePrice { get; set; }
        public ICollection<Consumption> Consumptions { get; set; }
    }
}