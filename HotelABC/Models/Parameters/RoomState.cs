using HotelABC.Models.Entities;

namespace HotelABC.Models.Parameters;

public class RoomState : BaseParameter
{
  public ICollection<Room> Rooms { get; set; }
}