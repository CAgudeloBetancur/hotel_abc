using HotelABC.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace HotelABC.Models.Parameters;

public class DocumentType : BaseParameter
{
    [Required]
    [MaxLength(5)]
    [RegularExpression(@"^[A-Z]{2,5}$", ErrorMessage = "Code must be 2 to 5 uppercase letters.")]
    public string Code { get; set; }

    public ICollection<ApplicationUser> Users { get; set; }
}
