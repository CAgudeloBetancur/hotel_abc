using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Complements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder
            .HasKey(g => g.Id);

        builder
            .Property(g => g.FirstName)
            .HasMaxLength(40)
            .IsRequired();

        builder
            .Property(g => g.LastName)
            .HasMaxLength(80)
            .IsRequired();

        builder
            .Property(g => g.DocumentValue)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(g => g.RelationshipId)
            .IsRequired();

        builder
            .Property(g => g.DocumentTypeId)
            .IsRequired();

        builder
            .Property(g => g.ReservationId)
            .IsRequired();

        builder
            .HasOne(g => g.Reservation)
            .WithMany()
            .HasForeignKey(g => g.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}