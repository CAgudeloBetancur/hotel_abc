using HotelABC.Models.Complements;

namespace HotelABC.Models.Parameters;

public class PaymentLogActionType : BaseParameter
{
  public ICollection<PaymentLog> PaymentLogs { get; set; }
}
