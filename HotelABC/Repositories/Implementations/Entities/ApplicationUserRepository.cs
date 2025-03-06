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
    public class ApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<bool> AddAsync(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return _userManager.Users;
        }

        public async Task<ApplicationUser> GetByIdAsync(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }
    }
}