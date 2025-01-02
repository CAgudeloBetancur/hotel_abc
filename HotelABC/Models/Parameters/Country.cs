using HotelABC.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace HotelABC.Models.Parameters;

public class Country : BaseParameter
{
    [Required]
    [MaxLength(3)]
    [RegularExpression(@"^[A-Z]{2,3}$", ErrorMessage = "ISO code must be 2 to 3 uppercase letters.")]
    public string IsoCode { get; set; }

    public ICollection<ApplicationUser> Users { get; set; }
}
