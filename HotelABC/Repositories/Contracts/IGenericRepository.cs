using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelABC.Repositories.Contracts;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> GetAll();
    Task<T> GetByIdAsync(Guid id);
    Task<bool> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<int> SaveChangesAsync();
}