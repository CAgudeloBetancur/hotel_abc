using HotelABC.Models.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class PaymentActionConfiguration : IEntityTypeConfiguration<PaymentLogActionType>
{
    public void Configure(EntityTypeBuilder<PaymentLogActionType> builder)
    {
        builder
            .HasKey(pa => pa.Id);

        builder
           .Property(pa => pa.Name)
           .IsRequired()
           .HasMaxLength(50)
           .UseCollation("SQL_Latin1_General_CP1_CI_AS") // Case insensitive
           .HasConversion(
               v => char.ToUpper(v[0]) + v.Substring(1).ToLower(), // Minuscula con inicial mayuscula
               v => v
               );
        builder
            .HasIndex(pa => pa.Name)
            .IsUnique();

        builder
            .Property(pa => pa.Description)
            .IsRequired(false)
            .HasMaxLength(150);
    }
}
