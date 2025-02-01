using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(40);
        
        builder
            .Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(80);

        builder
            .Property(c => c.DocumentValue)
            .IsRequired()
            .HasMaxLength(50);
        
        builder
            .HasIndex(c => c.DocumentValue)
            .IsUnique();

        builder
            .Property(c => c.PhoneNumber)
            .HasMaxLength(20);

        builder
            .Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .HasIndex(c => c.Email)
            .IsUnique();

        builder
            .Property(c => c.CountryId)
            .IsRequired();

        builder
            .Property(c => c.DocumentTypeId)
            .IsRequired();
    }
}