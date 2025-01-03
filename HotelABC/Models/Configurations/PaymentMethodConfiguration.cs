using HotelABC.Models.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder
            .HasKey(pm => pm.Id);

        builder
           .Property(pm => pm.Name)
           .IsRequired()
           .HasMaxLength(50)
           .UseCollation("SQL_Latin1_General_CP1_CI_AS") // Case insensitive
           .HasConversion(
               v => char.ToUpper(v[0]) + v.Substring(1).ToLower(), // Minuscula con inicial mayuscula
               v => v
               );
        builder
            .HasIndex(pm => pm.Name)
            .IsUnique();

        builder
            .Property(pm => pm.Description)
            .IsRequired(false)
            .HasMaxLength(180);
    }
}
