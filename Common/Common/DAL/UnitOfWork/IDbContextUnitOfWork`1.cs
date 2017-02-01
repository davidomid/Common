using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Common.DAL.UnitOfWork
{
    public interface IDbContextUnitOfWork<C> : IDbContextUnitOfWork where C : DbContext
    {
        C Context { get; }
    }
}
