using HotelABC.Models;
using HotelABC.Models.Complements;
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
    public DbSet<PaymentLogAction> PaymentActions { get; set; }
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

    public HotelABCDbContext(DbContextOptions options) : base(options) { }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(HotelABCDbContext).Assembly);
    }

}
