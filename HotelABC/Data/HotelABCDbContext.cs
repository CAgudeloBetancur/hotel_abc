using HotelABC.Models;
using HotelABC.Models.Entities;
using HotelABC.Models.Parameters;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelABC.Data;

public class HotelABCDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<RoomType> RoomTypes { get; set; }
    public DbSet<RoomState> RoomStates { get; set; }
    public DbSet<ReservationState> ReservationStates { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<PaymentState> PaymentStates { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<PaymentAction> PaymentActions { get; set; }
    public DbSet<OccupationState> OccupationSatates { get; set; }
    public DbSet<Relationship> Relationships { get; set; }
    public DbSet<ReportType> ReportTypes { get; set; }

    public DbSet<Client> Clients { get; set; }



    public HotelABCDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(HotelABCDbContext).Assembly);
    }
}
