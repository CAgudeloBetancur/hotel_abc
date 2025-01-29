using HotelABC.Models.Complements;
using HotelABC.Models.Entities;
using HotelABC.Models.Parameters;

namespace HotelABC.Models.Operations
{
  public class Occupation
  {
    public Guid Id { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Guid ReservationId { get; set; }
    public Guid OccupationStateId { get; set; }

    public Reservation Reservation { get; set; }
    public OccupationState OccupationState { get; set; }
    public ICollection<Consumption> Consumptions { get; set; }    
  }
}