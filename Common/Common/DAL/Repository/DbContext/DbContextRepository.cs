using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Common.DAL.Repository.DbContext
{
    public class DbContextRepository<C, T> : IDbContextRepository<T> where T : class
        where C : System.Data.Entity.DbContext
    {
        private readonly C _context;
        private DbSet<T> _dbSet;

        public DbContextRepository(C context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            this._context = context;
        }

        protected DbSet<T> DbSet => this._dbSet ?? (this._dbSet = this._context.Set<T>());

        IEnumerable<T> IRepository<T>.Get()
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<T> Get()
        {
            return this.DbSet;
        }

        public virtual void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            this.DbSet.Add(entity);
        }

        public virtual void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            this.DbSet.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            this._context.Entry(entity).State = EntityState.Modified;
        }

        public virtual Task<T> FindByKeyAsync(params object[] keyValues)
        {
            return this.DbSet.FindAsync(keyValues);
        }

        public virtual T FindByKey(params object[] keyValues)
        {
            return this.DbSet.Find(keyValues);
        }
    }
}