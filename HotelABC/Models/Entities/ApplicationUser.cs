using HotelABC.Models.Complements;
using HotelABC.Models.Operations;
using HotelABC.Models.Parameters;
using Microsoft.AspNetCore.Identity;

namespace HotelABC.Models.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DocumentValue { get; set; }
    
    public Guid CountryId { get; set; } 
    public Guid DocumentTypeId { get; set; }

    public Country Country { get; set; }
    public DocumentType DocumentType { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<Consumption> Consumptions { get; set; }
}
