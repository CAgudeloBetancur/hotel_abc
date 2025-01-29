using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Entities;
using HotelABC.Models.Operations;
using HotelABC.Models.Parameters;

namespace HotelABC.Models.Complements;

public class Consumption
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? Notes { get; set; } 

    public Guid OccupationId { get; set; }
    public Guid ConsumptionTypeId { get; set; }
    public Guid UserId { get; set; }

    public Occupation Occupation { get; set; }
    public ConsumptionType ConsumptionType { get; set; }
    public ApplicationUser User { get; set; }
    
}