using HotelABC.Models.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class PaymentStateConfiguration : IEntityTypeConfiguration<PaymentState>
{
    public void Configure(EntityTypeBuilder<PaymentState> builder)
    {
        builder
            .HasKey(ps => ps.Id);

        builder
           .Property(ps => ps.Name)
           .IsRequired()
           .HasMaxLength(50)
           .UseCollation("SQL_Latin1_General_CP1_CI_AS") // Case insensitive
           .HasConversion(
               v => char.ToUpper(v[0]) + v.Substring(1).ToLower(), // Minuscula con inicial mayuscula
               v => v
               );
        builder
            .HasIndex(ps => ps.Name)
            .IsUnique();

        builder
            .Property(ps => ps.Description)
            .IsRequired(false)
            .HasMaxLength(180);
    }
}
