using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Complements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HotelABC.Models.Configurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .Property(r => r.CreatedDate)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        builder
            .Property(r => r.ReportTypeId)
            .IsRequired();

        builder
            .Property(r => r.Parameters)
            .IsRequired()
            .HasMaxLength(int.MaxValue);

        builder
            .Property(r => r.Data)
            .IsRequired()
            .HasMaxLength(int.MaxValue);

        builder 
            .Property(r => r.Data)
            .HasAnnotation("nvarchar(max)", true);

        builder
            .ToTable(t => t.HasCheckConstraint("CK_Report_Parameters", "ISJSON(Parameters) = 1"));

        builder
            .ToTable(t => t.HasCheckConstraint("CK_Report_Data", "ISJSON(Data) = 1"));
    }
}