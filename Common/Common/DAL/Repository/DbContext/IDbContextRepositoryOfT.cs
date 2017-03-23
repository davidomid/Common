using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Common.DAL.Repository.DbContext
{
    public interface IDbContextRepository<T> : IDbContextRepository, IRepository<T> where T : class
    {
        new DbSet<T> Get();
    }
}