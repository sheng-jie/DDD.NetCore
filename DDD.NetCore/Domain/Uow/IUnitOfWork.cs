using System;
using DDD.NetCore.Domain.Entities;
using DDD.NetCore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DDD.NetCore.Domain.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity<int>;
        IRepository<TEntity, TPrimaryKey> GetRepository<TEntity, TPrimaryKey>()
            where TEntity : class, IEntity<TPrimaryKey>;
        

        void SaveChanges();

        IDbContextTransaction BeginTransaction();

    }

    public interface IUnitOfWork<out TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        TDbContext DbContext { get; }
    }
}