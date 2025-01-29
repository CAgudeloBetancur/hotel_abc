using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class OccupationConfiguration : IEntityTypeConfiguration<Occupation>
{
    public void Configure(EntityTypeBuilder<Occupation> builder)
    {
        builder
            .HasKey(o => o.Id);

        builder
            .Property(o => o.CheckInDate)
            .IsRequired();

        builder
            .Property(o => o.CheckOutDate)
            .IsRequired(false);

        builder
            .Property(c => c.CreatedAt)
            .IsRequired();

        builder
            .Property(c => c.UpdatedAt)
            .IsRequired();

        builder
            .Property(o => o.ReservationId)
            .IsRequired();

        builder
            .Property(c => c.OccupationStateId)
            .IsRequired();
    }
}