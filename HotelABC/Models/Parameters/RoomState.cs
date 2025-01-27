using HotelABC.Models.Entities;

namespace HotelABC.Models.Parameters;

public class RoomState : BaseParameter
{
  public IEnumerable<Room> Rooms { get; set; }
}