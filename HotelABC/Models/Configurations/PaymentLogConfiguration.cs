using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Complements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class PaymentLogConfiguration : IEntityTypeConfiguration<PaymentLog>
{
    public void Configure(EntityTypeBuilder<PaymentLog> builder)
    {
        builder
            .HasKey(pl => pl.Id);

        builder
            .Property(pl => pl.LogDate)
            .IsRequired();

        builder
            .Property(pl => pl.OldValue)
            .HasMaxLength(180)
            .IsRequired();

        builder
            .Property(pl => pl.NewValue)
            .HasMaxLength(180)
            .IsRequired();

        builder
            .Property(pl => pl.UserId)
            .IsRequired();

        builder
            .Property(pl => pl.ReservationId)
            .IsRequired();

        builder
            .Property(pl => pl.ClientId)
            .IsRequired();

        builder
            .Property(pl => pl.PaymentId)
            .IsRequired();

        builder
            .Property(pl => pl.PaymentLogActionId)
            .IsRequired();
    }
}