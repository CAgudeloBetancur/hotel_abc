using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Data.Contracts;
using HotelABC.Models.Entities;
using HotelABC.Repositories.Contracts;
using HotelABC.Repositories.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using HotelABC.Repositories.Implementations.Entities;

namespace HotelABC.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly HotelABCDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    private IDbContextTransaction _transaction;
    private bool _disposed = false;

    private Dictionary<string, object> _repositories;

    private IGenericRepository<ApplicationUser> _applicationUserRepository;
    public IGenericRepository<ApplicationUser> ApplicationUserRepository
    {
        get
        {
            if (_applicationUserRepository == null)
            {
                _applicationUserRepository = new ApplicationUserRepository(_userManager);
            }
            return _applicationUserRepository;
        }
    }

    public UnitOfWork(HotelABCDbContext _context, UserManager<ApplicationUser> userManager)
    {
        this._context = _context;
        this._userManager = userManager;
        _repositories = new Dictionary<string, object>();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        finally
        {
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }

    public async Task<int> CompleteAsync()
    {
        var result = await SaveChangesAsync();
        if(_transaction != null) 
        {
            await CommitTransactionAsync();
        }
        return result;
    }

    protected virtual void Dispose(bool disposing) 
    {
        if(!_disposed) 
        {
            if(disposing) 
            {
                if(_transaction != null) 
                {
                    _transaction.Dispose();
                    _transaction = null!;
                }
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public TRepo Repository<TRepo, TEntity>() 
        where TRepo : class, IGenericRepository<TEntity> 
        where TEntity : class
    {
        var type = typeof(TEntity).Name;
        if(!_repositories.ContainsKey(type)) 
        {
            var repositoryInstance = Activator.CreateInstance(typeof(TRepo), _context);
            _repositories.Add(type, repositoryInstance!);
        }
        return (TRepo)_repositories[type];
    }

    public async Task RollbackTransactionAsync()
    {
        try
        {
            await _transaction.RollbackAsync();
        }
        finally
        {
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}