using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Data;
using HotelABC.Models.Parameters;

namespace HotelABC.Repositories.Implementations;

public class RelationshipRepository : GenericRepository<Relationship>
{
    public RelationshipRepository(HotelABCDbContext context) : base(context) { }
}