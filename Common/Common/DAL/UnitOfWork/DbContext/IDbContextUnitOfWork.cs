using System.Threading.Tasks;

namespace Common.DAL.UnitOfWork.DbContext
{
    public interface IDbContextUnitOfWork : IUnitOfWork
    {
        new int Save();
        Task<int> SaveAsync();
        void Dispose(bool disposing);
    }
}