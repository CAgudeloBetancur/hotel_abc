namespace HotelABC.Data.Seeding;

public static class Roles
{
    public const string Admin = "Admin";
    public const string Receptionist = "Receptionist";
    public const string Housekeeping = "Housekeeping";
    public const string Maintenance = "Maintenance";

    public static readonly string[] AllRoles = { Admin, Receptionist, Housekeeping, Maintenance };
}
