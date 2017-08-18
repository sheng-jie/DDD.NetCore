using System;
using DDD.NetCore.Domain.Entities;
using DDD.NetCore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DDD.NetCore.Domain.Uow
{
    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        private bool _disposed = false;

        private IDbContextTransaction _transaction;

        private IServiceProvider _serviceProvider;
        public UnitOfWork(TDbContext dbContext,IServiceProvider serviceProvider)
        {
            DbContext = dbContext;
            _serviceProvider = serviceProvider;
        }


        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity<int>
        {
            var repository = GetRepository<TEntity, int>() as IRepository<TEntity>;
            return repository;
        }

        public IRepository<TEntity, TPrimaryKey> GetRepository<TEntity, TPrimaryKey>() where TEntity : class, IEntity<TPrimaryKey>
        {
            //return _serviceProvider.GetService<IRepository<TEntity, TPrimaryKey>>();
            return new EfCoreRepository<TDbContext, TEntity, TPrimaryKey>(DbContext);
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction()
        {
            _transaction = DbContext.Database.BeginTransaction();
            return _transaction;
        }

        public TDbContext DbContext { get; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">The disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction.Dispose();
                    DbContext.Dispose();
                }
            }

            _disposed = true;
        }

    }
}