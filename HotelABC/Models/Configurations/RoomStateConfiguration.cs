using HotelABC.Models.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class RoomStateConfiguration : IEntityTypeConfiguration<RoomState>
{
    public void Configure(EntityTypeBuilder<RoomState> builder)
    {
        builder
            .HasKey(rs => rs.Id);

        builder
           .Property(rs => rs.Name)
           .IsRequired()
           .HasMaxLength(50)
           .UseCollation("SQL_Latin1_General_CP1_CI_AS") // Case insensitive
           .HasConversion(
               v => char.ToUpper(v[0]) + v.Substring(1).ToLower(), // Minuscula con inicial mayuscula
               v => v
               );
        builder
            .HasIndex(rs => rs.Name)
            .IsUnique();

        builder
            .Property(rs => rs.Description)
            .IsRequired(false)
            .HasMaxLength(180);
    }
}
