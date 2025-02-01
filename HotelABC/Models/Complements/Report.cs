using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Parameters;

namespace HotelABC.Models.Complements;

public class Report : BaseModel
{
    public string Parameters { get; set; }
    public string Data { get; set; }
    public int Version { get; set; }

    public Guid ReportTypeId { get; set; }

    public ReportType ReportType { get; set; }
}