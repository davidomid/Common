using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Common.DAL.UnitOfWork
{
    public interface IDbContextUnitOfWork : IDisposable
    {
        void Save();
        Task<int> SaveAsync();
        void Dispose(bool disposing);
    }
}
