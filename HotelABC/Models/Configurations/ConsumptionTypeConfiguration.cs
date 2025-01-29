using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class ConsumptionTypeConfiguration : IEntityTypeConfiguration<ConsumptionType>
{
    public void Configure(EntityTypeBuilder<ConsumptionType> builder)
    {
        builder
            .HasKey(ct => ct.Id);

        builder
            .Property(ct => ct.Name)
            .IsRequired()
            .HasMaxLength(50)
            .UseCollation("SQL_Latin1_General_CP1_CI_AS") // Case insensitive
            .HasConversion(
                v => char.ToUpper(v[0]) + v.Substring(1).ToLower(), // Minuscula con inicial mayuscula
                v => v
                );

        builder
            .HasIndex(ct => ct.Name)
            .IsUnique();

        builder
            .Property(ct => ct.Description)
            .IsRequired(false)
            .HasMaxLength(200);

        builder
            .Property(ct => ct.BasePrice)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

    }
}