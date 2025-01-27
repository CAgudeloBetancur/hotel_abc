using HotelABC.Models.Entities;

namespace HotelABC.Models.Parameters;

public class RoomType : BaseParameter
{
  public IEnumerable<Room> Rooms { get; set; }
}
