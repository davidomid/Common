using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Common.DAL.Repository;

namespace Common.DAL.UnitOfWork
{
    public class DbContextUnitOfWork<C> : IDbContextUnitOfWork<C> where C : DbContext, new()
    {
        private readonly Dictionary<Type, IDbContextRepository> _genericRepositories =
            new Dictionary<Type, IDbContextRepository>();

        private bool _disposed;

        public DbContextUnitOfWork()
        {
            this.Context = new C();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            this.SaveAsync().Wait();
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await this.Context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbEntityValidationException dbEx)
            {
                string errorMessage = string.Empty;
                foreach (DbEntityValidationResult validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (DbValidationError validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}",
                            validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
            catch (DbUpdateException dbUEx)
            {
                string sqlError = (dbUEx.GetBaseException() as SqlException)?.Message;
                if (sqlError != null)
                {
                    throw new Exception(sqlError, dbUEx);
                }
            }
            return 0;
        }

        public C Context { get; }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                }
            }
            this._disposed = true;
        }

        public virtual IDbContextRepository<T> GetGenericRepository<T>() where T : class
        {
            if (this._genericRepositories.ContainsKey(typeof (T)))
            {
                return this._genericRepositories[typeof (T)] as IDbContextRepository<T>;
            }

            DbContextRepository<C, T> repository = new DbContextRepository<C, T>(this.Context);

            this._genericRepositories[typeof (T)] = repository;

            return repository;
        }
    }
}