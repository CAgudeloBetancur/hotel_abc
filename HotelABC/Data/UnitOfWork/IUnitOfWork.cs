using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelABC.Models.Entities;
using HotelABC.Models.Parameters;
using HotelABC.Repositories.Contracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HotelABC.Data.Contracts;

public interface IUnitOfWork : IDisposable
{
    TRepo Repository<TRepo, TEntity>() 
        where TRepo : class, IGenericRepository<TEntity> 
        where TEntity : class;
    IGenericRepository<ApplicationUser> ApplicationUserRepository { get; }

    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
    Task<int> CompleteAsync();

}