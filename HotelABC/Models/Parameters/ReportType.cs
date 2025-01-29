using HotelABC.Models.Complements;

namespace HotelABC.Models.Parameters;

public class ReportType : BaseParameter
{
    public ICollection<Report> Reports { get; set; }
}
