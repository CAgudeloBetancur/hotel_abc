using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Complements;
using HotelABC.Models.Parameters;

namespace HotelABC.Models.Operations;

public class Payment : BaseModel
{
    public DateTime PaymentDate { get; set; }
    public DateTime? DueDate { get; set; }
    public decimal Amount { get; set; }
    public string? TransactionId { get; set; }
    public string? Description { get; set; }
    
    public Guid PaymentStateId { get; set; }
    public Guid ReservationId { get; set; }
    public Guid PaymentMethodId { get; set; }

    public PaymentState PaymentState { get; set; }
    public Reservation Reservation { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public ICollection<PaymentLog> PaymentLogs { get; set; }
}