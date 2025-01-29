using HotelABC.Models.Operations;

namespace HotelABC.Models.Parameters;

public class ReservationState : BaseParameter
{
  public IEnumerable<Reservation> Reservations { get; set; }
}
