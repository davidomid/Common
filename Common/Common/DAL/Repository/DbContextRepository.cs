using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Common.DAL.Repository
{
    public class DbContextRepository<C, T> : IDbContextRepository<T> where T : class where C : DbContext, new()
    {
        private readonly C _context;

        public DbContextRepository(C context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            this._context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = this._context.Set<T>();
            return query;
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = this.GetAll().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            this._context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            this._context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            this._context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            try
            {
                this._context.SaveChanges();
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
        }
    }
}