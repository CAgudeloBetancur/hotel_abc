using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelABC.Models.Configurations;

public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        if(typeof(IAuditable).IsAssignableFrom(typeof(T)))
        {
            builder
                .Property<DateTime>("CreatedAt")
                .IsRequired()
                .HasDefaultValue("GETUTCDATE()");

            builder
                .Property<DateTime>("UpdatedAt")
                .IsRequired()
                .HasDefaultValue("GETUTCDATE()");
        }

        if(typeof(ISoftDeletable).IsAssignableFrom(typeof(T)))
        {
            builder
                .Property<bool>("IsDeleted")
                .IsRequired()
                .HasDefaultValue(false);

            builder
                .Property<DateTime?>("DeletedAt");

            builder
                .Property<Guid?>("DeletedBy");
        }
    }
}

// Configuración para las propiedades de IAuditable y ISoftDeletable para no hacerlas manualmente en cada modelo