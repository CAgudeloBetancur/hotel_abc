using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Complements;
using HotelABC.Models.Contracts;
using HotelABC.Models.Operations;
using HotelABC.Models.Parameters;

namespace HotelABC.Models.Entities;

public class Room : BaseModel
{
    [RegularExpression(@"^[A-Z]\d{3}$", ErrorMessage = "The code must start with capital letter followed by three digits.")]
    public string Number { get; set; }
    public decimal BasePrice { get; set; }

    public Guid RoomStateId { get; set; }
    public Guid RoomTypeId { get; set; }

    public RoomType RoomType { get; set; }
    public RoomState RoomState { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<RoomPriceHistory> RoomPriceHistories { get; set; }

    /* Calcular número de habitación nueva

    private string GenerateRoomNumber()
    {
        var lastRoomNumber = Rooms
            .OrderByDescending(r => r.Number)
            .Select(r => r.Number)
            .FirstOrDefault();

        if(string.IsNullOrEmpty(lastRoomNumber))
        {
            return "A001";
        }

        char letter = lastRoomNumber[0];
        int number = int.Parse(lastRoomNumber.Substring(1));

        if(number < 999) number++; 
        else 
        { 
            letter = (char)(letter + 1); 
            number = 1; 
        }

        return $"{letter}{number:D3}";
    }

    */
}