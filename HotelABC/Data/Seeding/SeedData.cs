using HotelABC.Models.Entities;
using HotelABC.Models.Parameters;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System.Drawing.Text;
using System.Text.Json;

namespace HotelABC.Data.Seeding;

public static class SeedData
{
    public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        foreach(var role in Roles.AllRoles)
        {
            if(!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync( new IdentityRole(role) );
            }
        }
    }

    public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager, HotelABCDbContext dbContext)
    {

        var countryId = dbContext
            .Countries
            .Where(c => c.Name == "Colombia")
            .Select(c => c.Id)
            .FirstOrDefault();

        foreach(var user in Users.AllUsers)
        {
            await SeedUserByRole(
                userManager, 
                user.Email, 
                user.RoleName,
                user.FirstName, 
                user.LastName, 
                user.DocumentValue, 
                user.PhoneNumber, 
                countryId,
                DocumentTypes.AllDocumentTypes[0].Id, // Cedula
                user.Password
                );
        }

    }

    private static async Task SeedUserByRole(
        UserManager<ApplicationUser> userManager,
        string email,
        string roleName,
        string firstName,
        string lastName,
        string documentValue,
        string phoneNumber,
        Guid countryId,
        Guid documentTypeId,
        string password
        )
    {
        var user = await userManager.FindByEmailAsync( email );

        if( user == null )
        {
            user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                FirstName = firstName,
                LastName = lastName,
                DocumentValue = documentValue,
                PhoneNumber = phoneNumber,
                CountryId = countryId,
                DocumentTypeId = documentTypeId
            };

            var result = await userManager.CreateAsync(user, password);

            if(result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, roleName);
            }
            else
            {
                throw new Exception($"Error al crear el usuario {email} : {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }

    public static async Task SeedDocumentTypes(HotelABCDbContext dbContext)
    {
        if (dbContext.DocumentTypes.Any()) return;

        foreach(var document in DocumentTypes.AllDocumentTypes)
        {
            if(!await dbContext.DocumentTypes.AnyAsync(d => d.Name == document.Name))
            {
                await dbContext.DocumentTypes.AddRangeAsync(DocumentTypes.AllDocumentTypes);
            }
        }

        await dbContext.SaveChangesAsync();
    }

    public static async Task SeedCountriesAsync(HotelABCDbContext dbContext)
    {
        if (dbContext.Countries.Any()) return;

        const string apiUrl = "https://restcountries.com/";
        const string requestUri = "v3.1/all?fields=name,cca2";

        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(apiUrl);
        HttpResponseMessage response = await httpClient.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();

        using var jsonDocument = JsonDocument.Parse(json);

        var countriesData = jsonDocument
            .RootElement
            .EnumerateArray()
            .Where(c => c.TryGetProperty("name", out var name) && name.GetProperty("common").GetString() != null)
            .Select(c => new Country
            {
                Id = Guid.NewGuid(),
                Name = c.GetProperty("name").GetProperty("common").GetString()!,
                IsoCode = c.GetProperty("cca2").GetString()!.ToUpper(),
                Description = c.GetProperty("name").GetProperty("official").GetString()
            })
            .ToList();

        await dbContext.Countries.AddRangeAsync(countriesData);
        await dbContext.SaveChangesAsync();

        // var countriesData = await httpClient.GetFromJsonAsync<List<CountryApiModel>>(apiUrl);

        /*if(countriesData != null )
        {
            var countries = countriesData
                .Where(c => !string.IsNullOrWhiteSpace(c.Name.Common) && !string.IsNullOrWhiteSpace(c.Cca2))
                .Select(c => new Country
                {
                    Id = Guid.NewGuid(),
                    Name = c.Name.Common,
                    IsoCode = c.Cca2.ToUpper(),
                    Description = c.Name.Official
                })
                .ToList();

            await dbContext.Countries.AddRangeAsync(countries);
            await dbContext.SaveChangesAsync();
        }*/

    }

    public class CountryApiModel
    {

        public NameModel Name { get; set; }
        public string Cca2 { get; set; }
        public string Cca3 { get; set; }

        public class NameModel
        {
            public string Common { get; set; }
            public string Official { get; set; }
        }

    }

    
}
