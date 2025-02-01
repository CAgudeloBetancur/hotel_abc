using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Entities;
using HotelABC.Models.Operations;
using HotelABC.Models.Parameters;

namespace HotelABC.Models.Complements;

public class PaymentLog : BaseModel
{
    public DateTime LogDate { get; set; }
    public string? OldValue { get; set; }
    public string NewValue { get; set; }

    public Guid PaymentId { get; set; }
    public Guid PaymentLogActionTypeId { get; set; }

    public Payment Payment { get; set; }
    public PaymentLogActionType PaymentLogActionType { get; set; }
}