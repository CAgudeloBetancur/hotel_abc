using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HotelABC.Data;
using HotelABC.Models.Entities;
using HotelABC.Data.Seeding;
using HotelABC.Data.Interceptors;
using HotelABC.Repositories.Contracts;
using HotelABC.Repositories.Implementations;
using HotelABC.Repositories.Implementations.Entities;
using HotelABC.Data.Contracts;
using HotelABC.Data.UnitOfWork;
using HotelABC.Mapping;

var builder = WebApplication.CreateBuilder(args);

// |-- IdentityDbContext & Identity Views

var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'HotelABCDbContextConnection' not found.");

// | -- Add services to the container.

builder
    .Services
    .AddDbContext<HotelABCDbContext>( options => options.UseSqlServer(connectionString) );

builder
    .Services
    .AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<HotelABCDbContext>();

builder
    .Services
    .AddRazorPages();

// --|

// | -- Context Accessor para el interceptor

builder
    .Services
    .AddHttpContextAccessor();

// | -- SoftDeleteInterceptor

builder
    .Services
    .AddScoped<SoftDeleteInterceptor>();

// -- Repositories

builder
    .Services
    .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder
    .Services
    .AddScoped<IGenericRepository<ApplicationUser>, ApplicationUserRepository>();

// -- UnitOfWork

builder
    .Services
    .AddScoped<IUnitOfWork, UnitOfWork>();

// -- Mapping

builder
    .Services
    .AddAutoMapper(typeof(MappingProfile));

// -- Controllers

builder.Services.AddControllersWithViews();

var app = builder.Build();

// |-- Seeding

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<HotelABCDbContext>();

    await SeedData.SeedRolesAsync(roleManager);
    await SeedData.SeedCountriesAsync(dbContext);
    await SeedData.SeedDocumentTypes(dbContext);
    await SeedData.SeedUsersAsync(userManager, dbContext);
}

// --|

// | -- Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
    app.UseHsts();
}
else 
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// |-- Identity Views Mapping

app.MapRazorPages();

// --|

app.Run();
