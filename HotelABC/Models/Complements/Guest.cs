using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Operations;
using HotelABC.Models.Parameters;

namespace HotelABC.Models.Complements;

public class Guest : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DocumentValue { get; set; }

    public Guid RelationshipId { get; set; }
    public Guid DocumentTypeId { get; set; }
    public Guid ReservationId { get; set; }

    public Relationship Relationship { get; set; }
    public DocumentType DocumentType { get; set; }
    public Reservation Reservation { get; set; }
}