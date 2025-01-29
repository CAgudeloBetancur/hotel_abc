using HotelABC.Models.Operations;

namespace HotelABC.Models.Parameters;

public class OccupationState : BaseParameter
{
    public IEnumerable<Occupation> Occupations { get; set; }
}
