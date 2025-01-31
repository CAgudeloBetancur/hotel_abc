using HotelABC.Models.Operations;

namespace HotelABC.Models.Parameters;

public class PaymentState : BaseParameter
{
  public ICollection<Payment> Payments { get; set; }
}
