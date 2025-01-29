using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.PaymentDate)
            .IsRequired();

        builder
            .Property(p => p.DueDate)
            .IsRequired(false);

        builder
            .Property(p => p.Amount)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder
            .Property(p => p.TransactionId)
            .HasMaxLength(180)
            .IsRequired(false);

        builder
            .Property(p => p.Description)
            .HasMaxLength(180)
            .IsRequired(false);

        builder
            .Property(p => p.CreatedAt)
            .IsRequired();

        builder
            .Property(p => p.UpdatedAt)
            .IsRequired();

        builder
            .Property(p => p.PaymentStateId)
            .IsRequired();

        builder
            .Property(p => p.ReservationId)
            .IsRequired();

        builder
            .Property(p => p.PaymentMethodId)
            .IsRequired();
    }
}