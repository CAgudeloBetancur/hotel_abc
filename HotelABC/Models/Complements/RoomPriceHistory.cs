using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Entities;

namespace HotelABC.Models.Complements;

public class RoomPriceHistory : BaseModel
{
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public Guid RoomId { get; set; }

    public Room Room { get; set; }
}