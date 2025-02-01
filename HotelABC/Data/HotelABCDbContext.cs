using System.Linq.Expressions;
using HotelABC.Data.Interceptors;
using HotelABC.Models;
using HotelABC.Models.Complements;
using HotelABC.Models.Configurations;
using HotelABC.Models.Contracts;
using HotelABC.Models.Entities;
using HotelABC.Models.Operations;
using HotelABC.Models.Parameters;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelABC.Data;

public class HotelABCDbContext : IdentityDbContext<ApplicationUser>
{
    // Parámeters
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<RoomState> RoomStates { get; set; }
    public DbSet<ReservationState> ReservationStates { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<PaymentState> PaymentStates { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<PaymentLogActionType> PaymentLogActionTypes { get; set; }
    public DbSet<OccupationState> OccupationSatates { get; set; }
    public DbSet<Relationship> Relationships { get; set; }
    public DbSet<ReportType> ReportTypes { get; set; }
    public DbSet<ConsumptionType> ConsumptionTypes { get; set; }

    // Entities
    public DbSet<Client> Clients { get; set; }
    public DbSet<Room> Rooms { get; set; }

    // Operations
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Occupation> Ocupations { get; set; }
    public DbSet<Payment> Payments { get; set; }

    // Complements
    public DbSet<Guest> Guests { get; set; }
    public DbSet<PaymentLog> PaymentLogs { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Consumption> Consumptions { get; set; }
    public DbSet<RoomPriceHistory> RoomPriceHistories { get; set; }

    // Interceptors

    private readonly SoftDeleteInterceptor _softDeleteInterceptor;

    public HotelABCDbContext(DbContextOptions options, SoftDeleteInterceptor softDeleteInterceptor) : base(options)
    {
        _softDeleteInterceptor = softDeleteInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Agregamos todas las configuraciones de los modelos

        builder.ApplyConfigurationsFromAssembly(typeof(HotelABCDbContext).Assembly);


        foreach(var entityType in builder.Model.GetEntityTypes())
        {
            // Filtro para ignorar registros con IsDeleted = false

            if(typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, nameof(ISoftDeletable.IsDeleted));
                var filter = Expression.Lambda(Expression.Equal(property, Expression.Constant(false)), parameter);
                builder.Entity(entityType.ClrType).HasQueryFilter(filter);
            }
        }

        base.OnModelCreating(builder);
    }

    // Agregar interceptor
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_softDeleteInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    // actualizar automáticamente CreatedAt & UpdatedAt
    public override int SaveChanges()
    {
        ChangeAuditableProperties();

        return base.SaveChanges();
    }

    // actualizar automáticamente CreatedAt & UpdatedAt
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeAuditableProperties();

        return base.SaveChangesAsync(cancellationToken);
    }

    private void ChangeAuditableProperties()
    {
        foreach(var entry in ChangeTracker.Entries<IAuditable>())
        {
            if(entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
            else if(entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
