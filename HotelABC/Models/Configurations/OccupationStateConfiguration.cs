using HotelABC.Models.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class OccupationStateConfiguration : IEntityTypeConfiguration<OccupationState>
{
    public void Configure(EntityTypeBuilder<OccupationState> builder)
    {
        builder
            .HasKey(os => os.Id);

        builder
           .Property(os => os.Name)
           .IsRequired()
           .HasMaxLength(30)
           .UseCollation("SQL_Latin1_General_CP1_CI_AS") // Case insensitive
           .HasConversion(
               v => char.ToUpper(v[0]) + v.Substring(1).ToLower(), // Minuscula con inicial mayuscula
               v => v
               );
        builder
            .HasIndex(os => os.Name)
            .IsUnique();

        builder
            .Property(os => os.Description)
            .IsRequired(false)
            .HasMaxLength(180);
    }
}
