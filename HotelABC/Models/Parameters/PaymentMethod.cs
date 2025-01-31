using HotelABC.Models.Operations;

namespace HotelABC.Models.Parameters;

public class PaymentMethod : BaseParameter
{
  public ICollection<Payment> Payments { get; set; }
}
