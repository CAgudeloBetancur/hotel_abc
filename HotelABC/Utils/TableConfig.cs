using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Complements;
using HotelABC.Models.Entities;
using HotelABC.Models.Operations;
using HotelABC.Models.Parameters;

namespace HotelABC.Utils;

public static class TableConfig
{
    private static readonly string[] ParameterProps = new[] {"Id", "Name", "Description"};

    private static readonly Dictionary<Type, string[]> ColumnMappings = new() 
    {
        // Parameters
        { typeof(ConsumptionType), ParameterProps.Concat( new[] {"BasePrice"} ).ToArray() },
        { typeof(Country), ParameterProps.Concat( new[] {"IsoCode"} ).ToArray() },
        { typeof(DocumentType), ParameterProps.Concat( new[] {"Code"} ).ToArray() },
        { typeof(OccupationState), ParameterProps },
        { typeof(PaymentLogActionType), ParameterProps },
        { typeof(PaymentMethod), ParameterProps },
        { typeof(PaymentState), ParameterProps },
        { typeof(Relationship), ParameterProps },
        { typeof(ReportType), ParameterProps },
        { typeof(ReservationState), ParameterProps },
        { typeof(RoomState), ParameterProps },
        { typeof(RoomType), ParameterProps },
        // Entities
        { typeof(ApplicationUser), new[] {"Id", "DocumentValue", "FirstName", "LastName", "Email", "PhoneNumber"} },
        { typeof(Client), new[] {"Id", "FisrtName", "DocumentValue", "Email", "PhoneNumber"} },
        { typeof(Room), new[] {"Id", "Number", "BasePrice", "RoomTypeId", "RoomStateId"} },
        // Operations
        { typeof(Occupation), new[] {"Id", "CheckInDate", "CheckOutDate", "ReservationId", "OccupationStateId"} },
        { typeof(Payment), new[] {"Id", "PaymentDate", "DueDate", "Amount", "TransactionId", "PaymentStateId"} },
        { typeof(Reservation), new[] {"Id", "CheckInDate", "CheckOutDate", "TotalCost", "ClientId", "ReservationStateId"} },
        // Complements
        { typeof(Consumption), new[] {"Id", "Quantity", "UnitPrice", "Total", "ConsumptionTypeId", "UserId"} },
        { typeof(Guest), new[] {"Id", "FirstName", "LastName", "DocumentTypeId", "DocumentValue", "ReservationId"} },
        { typeof(PaymentLog), new[] {"Id", "LogDate", "OldValue", "NewValue", "PaymentId", "PaymentLogActionTypeId"} },
        { typeof(Report), new[] {"Id", "Parameters", "Data", "Version", "ReportTypeId"} },
        { typeof(RoomPriceHistory), new[] {"Id", "Price", "StartDate", "EndDate", "RoomId"} },        
    };

    public static string[] GetColumnsFor<T>() {
        return ColumnMappings.TryGetValue(typeof(T), out var columns) ? columns : Array.Empty<string>();
    }
}