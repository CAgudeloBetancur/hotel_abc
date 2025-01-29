using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Entities;
using HotelABC.Models.Operations;
using HotelABC.Models.Parameters;

namespace HotelABC.Models.Complements;

public class PaymentLog
{
    public Guid Id { get; set; }
    public DateTime LogDate { get; set; }
    public string? OldValue { get; set; }
    public string NewValue { get; set; }

    public Guid UserId { get; set; }
    public Guid ReservationId { get; set; }
    public Guid ClientId { get; set; }
    public Guid PaymentId { get; set; }
    public Guid PaymentLogActionId { get; set; }

    public ApplicationUser User { get; set; }
    public Reservation Reservation { get; set; }
    public Client Client { get; set; }
    public Payment Payment { get; set; }
    public PaymentLogAction PaymentLogAction { get; set; }
}