using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelABC.Models.Parameters;
using HotelABC.Models.ViewModels.Parameters.ConsumptionType;
using HotelABC.Models.ViewModels.Parameters.Country;
using HotelABC.Models.ViewModels.Parameters.DocumentType;
using HotelABC.Models.ViewModels.Parameters.OccupationState;
using HotelABC.Models.ViewModels.Parameters.PaymentLogActionType;
using HotelABC.Models.ViewModels.Parameters.PaymentMethod;
using HotelABC.Models.ViewModels.Parameters.PaymentState;
using HotelABC.Models.ViewModels.Parameters.Relationship;
using HotelABC.Models.ViewModels.Parameters.ReportType;
using HotelABC.Models.ViewModels.Parameters.ReservationState;
using HotelABC.Models.ViewModels.Parameters.RoomState;
using HotelABC.Models.ViewModels.Parameters.RoomType;

namespace HotelABC.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        // Mapping for Parameters

        CreateMap<ConsumptionType, ConsumptionTypeCreateViewModel>().ReverseMap();
        CreateMap<ConsumptionType, ConsumptionTypeEditViewModel>().ReverseMap();

        CreateMap<Country, CountryCreateViewModel>().ReverseMap();
        CreateMap<Country, CountryEditViewModel>().ReverseMap();

        CreateMap<DocumentType, DocumentTypeCreateViewModel>().ReverseMap();
        CreateMap<DocumentType, DocumentTypeEditViewModel>().ReverseMap();

        CreateMap<OccupationState, OccupationStateCreateViewModel>().ReverseMap();
        CreateMap<OccupationState, OccupationStateEditViewModel>().ReverseMap();

        CreateMap<PaymentLogActionType, PaymentLogActionTypeCreateViewModel>().ReverseMap();
        CreateMap<PaymentLogActionType, PaymentLogActionTypeEditViewModel>().ReverseMap();

        CreateMap<PaymentMethod, PaymentMethodCreateViewModel>().ReverseMap();
        CreateMap<PaymentMethod, PaymentMethodEditViewModel>().ReverseMap();

        CreateMap<PaymentState, PaymentStateCreateViewModel>().ReverseMap();
        CreateMap<PaymentState, PaymentStateEditViewModel>().ReverseMap();

        CreateMap<Relationship, RelationshipCreateViewModel>().ReverseMap();
        CreateMap<Relationship, RelationshipEditViewModel>().ReverseMap();

        CreateMap<ReportType, ReportTypeCreateViewModel>().ReverseMap();
        CreateMap<ReportType, ReportTypeEditViewModel>().ReverseMap();

        CreateMap<ReservationState, ReservationStateCreateViewModel>().ReverseMap();
        CreateMap<ReservationState, ReservationStateEditViewModel>().ReverseMap();

        CreateMap<RoomState, RoomStateCreateViewModel>().ReverseMap();
        CreateMap<RoomState, RoomStateEditViewModel>().ReverseMap();

        CreateMap<RoomType, RoomTypeCreateViewModel>().ReverseMap();
        CreateMap<RoomType, RoomTypeEditViewModel>().ReverseMap();
    }
}