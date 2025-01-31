using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .Property(r => r.CheckInDate)
            .IsRequired();

        builder
            .Property(r => r.CheckOutDate)
            .IsRequired(false);

        builder
            .Property(r => r.TotalCost)
            .HasColumnType("decimal(10,2)")
            .IsRequired(false);

        builder
            .Property(r => r.CreatedAt)
            .IsRequired();

        builder
            .Property(r => r.UpdatedAt)
            .IsRequired();

        builder
            .Property(r => r.CancellationDate)
            .IsRequired(false);

        builder
            .Property(r => r.CancellationFee)
            .HasColumnType("decimal(10,2)")
            .IsRequired(false);

        builder
            .HasIndex(r => new { r.ClientId, r.CheckInDate, r.CheckOutDate });

        builder
            .Property(r => r.UserId)
            .IsRequired();

        builder
            .Property(r => r.ClientId)
            .IsRequired();

        builder
            .Property(r => r.ReservationStateId)
            .IsRequired();
    }
}