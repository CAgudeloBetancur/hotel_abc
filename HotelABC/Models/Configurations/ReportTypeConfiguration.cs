using HotelABC.Models.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class ReportTypeConfiguration : IEntityTypeConfiguration<ReportType>
{
    public void Configure(EntityTypeBuilder<ReportType> builder)
    {
        builder
            .HasKey(rt => rt.Id);

        builder
           .Property(rt => rt.Name)
           .IsRequired()
           .HasMaxLength(40)
           .UseCollation("SQL_Latin1_General_CP1_CI_AS") // Case insensitive
           .HasConversion(
               v => char.ToUpper(v[0]) + v.Substring(1).ToLower(), // Minuscula con inicial mayuscula
               v => v
               );
        builder
            .HasIndex(rt => rt.Name)
            .IsUnique();

        builder
            .Property(rt => rt.Description)
            .IsRequired(false)
            .HasMaxLength(180);
    }
}
