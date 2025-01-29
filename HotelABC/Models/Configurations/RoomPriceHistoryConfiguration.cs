using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Complements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class RoomPriceHistoryConfiguration : IEntityTypeConfiguration<RoomPriceHistory>
{
    public void Configure(EntityTypeBuilder<RoomPriceHistory> builder)
    {
        builder
            .HasKey(rph => rph.Id);

        builder
            .Property(rph => rph.Price)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        builder
            .Property(rph => rph.StartDate)
            .IsRequired();

        builder
            .Property(rph => rph.EndDate)
            .IsRequired(false);

        builder
            .Property(rph => rph.CreatedAt)
            .IsRequired();

        builder
            .Property(rph => rph.UpdatedAt)
            .IsRequired();

        builder
            .Property(rph => rph.RoomId)
            .IsRequired();
    }
}