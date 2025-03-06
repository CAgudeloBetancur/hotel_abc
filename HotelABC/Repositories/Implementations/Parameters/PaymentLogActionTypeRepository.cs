using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Data;
using HotelABC.Models.Parameters;

namespace HotelABC.Repositories.Implementations;

public class PaymentLogActionTypeRepository : GenericRepository<PaymentLogActionType>
{
    public PaymentLogActionTypeRepository(HotelABCDbContext context) : base(context) { }
}