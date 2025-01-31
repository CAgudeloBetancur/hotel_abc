using HotelABC.Models.Operations;

namespace HotelABC.Models.Parameters;

public class OccupationState : BaseParameter
{
    public ICollection<Occupation> Occupations { get; set; }
}
