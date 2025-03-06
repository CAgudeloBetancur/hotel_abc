using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Data;
using HotelABC.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HotelABC.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly HotelABCDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(HotelABCDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<bool> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return Task.FromResult(true).Result;
    }

    public virtual async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if(entity != null) {
            _dbSet.Remove(entity);
            return Task.FromResult(true).Result;
        }
        return Task.FromResult(false).Result;
    }

    public virtual IQueryable<T> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public virtual async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public virtual Task<bool> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.FromResult(true);
    }
}