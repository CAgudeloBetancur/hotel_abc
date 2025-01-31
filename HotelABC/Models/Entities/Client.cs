using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Operations;
using HotelABC.Models.Parameters;

namespace HotelABC.Models;

public class Client
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DocumentValue { get; set; }
    [RegularExpression(
        @"^\d{7,20}$", 
        ErrorMessage = "Phone number must contain between 7 and 20 digits and cannot contain spaces or non-numeric characters."
        )]
    public string? PhoneNumber { get; set; } 
    [EmailAddress]
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Guid CountryId { get; set; }
    public Guid DocumentTypeId { get; set; }

    public Country Country { get; set; }
    public DocumentType DocumentType { get; set; }
    public ICollection<Reservation> Reservations { get; set; }

}