using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common.DAL.Repository
{
    public interface IRepository<T> : IRepository where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
