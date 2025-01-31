using HotelABC.Models.Operations;

namespace HotelABC.Models.Parameters;

public class ReservationState : BaseParameter
{
  public ICollection<Reservation> Reservations { get; set; }
}
