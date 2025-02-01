using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .Property(r => r.Number)
            .IsRequired()
            .HasMaxLength(4)
            .HasAnnotation("RegularExpression", @"^[A-Z]\d{3}$");

        builder
            .HasIndex(r => r.Number)
            .IsUnique();

        builder
            .Property(r => r.BasePrice)
            .HasColumnType("decimal(10,2)")
            .IsRequired();

        builder
            .Property(r => r.RoomStateId)
            .IsRequired();

        builder
            .Property(r => r.RoomTypeId)
            .IsRequired();
    }
}