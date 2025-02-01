using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Complements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class ConsumptionConfiguration : IEntityTypeConfiguration<Consumption>
{
    public void Configure(EntityTypeBuilder<Consumption> builder)
    {
        builder 
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Quantity)
            .IsRequired();

        builder
            .Property(c => c.UnitPrice)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder 
            .Property(c => c.Total)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder
            .Property(c => c.Notes)
            .IsRequired(false)
            .HasMaxLength(255);

        builder
            .Property(c => c.OccupationId)
            .IsRequired();

        builder
            .Property(c => c.ConsumptionTypeId)
            .IsRequired();

        builder
            .Property(c => c.UserId)
            .IsRequired();
    }
}