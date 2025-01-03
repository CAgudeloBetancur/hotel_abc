using HotelABC.Models.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class RelationshipConfiguration : IEntityTypeConfiguration<Relationship>
{
    public void Configure(EntityTypeBuilder<Relationship> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
           .Property(r => r.Name)
           .IsRequired()
           .HasMaxLength(20)
           .UseCollation("SQL_Latin1_General_CP1_CI_AS") // Case insensitive
           .HasConversion(
               v => char.ToUpper(v[0]) + v.Substring(1).ToLower(), // Minuscula con inicial mayuscula
               v => v
               );
        builder
            .HasIndex(r => r.Name)
            .IsUnique();

        builder
            .Property(r => r.Description)
            .IsRequired(false)
            .HasMaxLength(100);
    }
}
