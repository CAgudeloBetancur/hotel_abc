using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Data;
using HotelABC.Models.Entities;
using HotelABC.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;

namespace HotelABC.Repositories.Implementations.Entities
{
    public class ClientRepository : GenericRepository<Client>
    {
        public ClientRepository(HotelABCDbContext context) : base(context) { }
    }
}