namespace HotelABC.Data.Seeding;

public static class Users
{
    public static readonly (string Email, string FirstName, string LastName, string DocumentValue, string PhoneNumber, string Password, string RoleName)[] AllUsers =
    {
        (
            "admin@admin.com", 
            Roles.Admin, 
            Roles.Admin, 
            "2141234", 
            "12345678", 
            "Admin_2024", 
            Roles.Admin
        ),
        (
            "receptionist@receptionist.com", 
            Roles.Receptionist, 
            Roles.Receptionist, 
            "341234", 
            "12345678", 
            "Receptionist_2024", 
            Roles.Receptionist
        ),
        (
            "maintenance@maintenance.com", 
            Roles.Maintenance, 
            Roles.Maintenance, 
            "12342348", 
            "12345678", 
            "Maintenance_2024", 
            Roles.Maintenance
        ),
        (
            "housekeeping@housekeeping.com", 
            Roles.Housekeeping, 
            Roles.Housekeeping, 
            "123456722", 
            "12345678", 
            "Housekeeping_2024", 
            Roles.Housekeeping
        ),
    };
}
