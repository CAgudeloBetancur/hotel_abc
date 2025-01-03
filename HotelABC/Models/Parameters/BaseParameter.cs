namespace HotelABC.Models.Parameters;

public abstract class BaseParameter
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}
