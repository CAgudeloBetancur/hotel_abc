using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Data;
using HotelABC.Models.Parameters;

namespace HotelABC.Repositories.Implementations;

public class ReservationStateRepository : GenericRepository<ReservationState>
{
    public ReservationStateRepository(HotelABCDbContext context) : base(context) { }
}