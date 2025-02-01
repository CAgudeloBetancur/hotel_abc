using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Complements;
using HotelABC.Models.Entities;
using HotelABC.Models.Parameters;

namespace HotelABC.Models.Operations;

public class Reservation : BaseModel
{
    public DateTime CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public decimal? TotalCost { get; set; }

    public DateTime? CancellationDate { get; set; }
    public decimal? CancellationFee { get; set; }

    public Guid UserId { get; set; }
    public Guid ClientId { get; set; }
    public Guid ReservationStateId { get; set; }

    public ApplicationUser User { get; set; }
    public Client Client { get; set; }
    public ReservationState ReservationState { get; set; }
    public ICollection<Room> Rooms { get; set; }
    public ICollection<Occupation> Occupations { get; set; }
    public ICollection<Guest> Guests { get; set; }
    public ICollection<Payment> Payments { get; set; }

}