using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using HotelABC.Data;
using HotelABC.Data.Contracts;
using HotelABC.Models.Parameters;
using HotelABC.Models.ViewModels.Parameters.PaymentLogActionType;
using HotelABC.Repositories.Contracts;
using HotelABC.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelABC.Controllers;

[Route("[controller]")]
public class PaymentLogActionTypeController 
    : GenericController
        <PaymentLogActionType, PaymentLogActionTypeCreateViewModel, PaymentLogActionTypeEditViewModel, PaymentLogActionTypeRepository>
{

    public PaymentLogActionTypeController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
}