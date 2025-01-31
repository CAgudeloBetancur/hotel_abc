using HotelABC.Models.Entities;

namespace HotelABC.Models.Parameters;

public class RoomType : BaseParameter
{
  public ICollection<Room> Rooms { get; set; }
}
