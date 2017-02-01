namespace Common.DAL.Repository
{
    public interface IDbContextRepository<T> : IDbContextRepository, IRepository<T> where T : class
    {
    }
}