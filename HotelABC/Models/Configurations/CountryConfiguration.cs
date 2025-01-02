using HotelABC.Models.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100)
            .UseCollation("SQL_Latin1_General_CP1_CI_AS") // Case insensitive
            .HasConversion(
                v => char.ToUpper(v[0]) + v.Substring(1).ToLower(), // Minuscula con inicial mayuscula
                v => v
                );
        builder
            .HasIndex(c => c.Name)
            .IsUnique();

        builder
            .Property(c => c.Description)
            .IsRequired(false)
            .HasMaxLength(100);

        builder
            .Property(c => c.IsoCode)
            .IsRequired()
            .HasMaxLength(3)
            .IsUnicode(false)
            .UseCollation("SQL_Latin1_General_CP1_CI_AS")
            .HasConversion(
                v => v.ToUpper(),
                v => v
                );
        builder
            .HasIndex(c => c.IsoCode)
            .IsUnique();           

    }
}
