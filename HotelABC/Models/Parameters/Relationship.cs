using HotelABC.Models.Complements;

namespace HotelABC.Models.Parameters;

public class Relationship : BaseParameter
{
    public ICollection<Guest> Guests { get; set; }
}
