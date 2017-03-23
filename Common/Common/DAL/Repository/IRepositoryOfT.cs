using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Common.DAL.Repository
{
    public interface IRepository<T> : IRepository where T : class
    {
        IEnumerable<T> Get();
        void Add(T item);
        void Remove(T item);
        void Update(T item);
    }
}