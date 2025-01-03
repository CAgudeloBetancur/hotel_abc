using HotelABC.Models.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
{
    public void Configure(EntityTypeBuilder<DocumentType> builder)
    {
        builder
            .HasKey(dt => dt.Id);

        builder
           .Property(dt => dt.Name)
           .IsRequired()
           .HasMaxLength(50)
           .UseCollation("SQL_Latin1_General_CP1_CI_AS") // Case insensitive
           .HasConversion(
               v => char.ToUpper(v[0]) + v.Substring(1).ToLower(), // Minuscula con inicial mayuscula
               v => v
               );
        builder
            .HasIndex(dt => dt.Name)
            .IsUnique();

        builder
            .Property(c => c.Description)
            .IsRequired(false)
            .HasMaxLength(100);

        builder
            .Property(dt => dt.Code)
            .IsRequired()
            .HasMaxLength(5)
            .IsUnicode(false)
            .UseCollation("SQL_Latin1_General_CP1_CI_AS")
            .HasConversion(
                v => v.ToUpper(),
                v => v
                );
        builder
            .HasIndex(c => c.Code)
            .IsUnique();

    }
}
