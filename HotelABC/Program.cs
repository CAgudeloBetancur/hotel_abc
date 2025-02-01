using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HotelABC.Data;
using HotelABC.Models.Entities;
using HotelABC.Data.Seeding;
using HotelABC.Data.Interceptors;

var builder = WebApplication.CreateBuilder(args);

// |-- IdentityDbContext & Identity Views

var connectionString = builder
    .Configuration
    .GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'HotelABCDbContextConnection' not found.");

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

// | -- Add services to the container.

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
    app.UseHsts();
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
