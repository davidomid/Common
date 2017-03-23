namespace Common.DAL.UnitOfWork.DbContext
{
    public interface IDbContextUnitOfWork<C> : IDbContextUnitOfWork where C : System.Data.Entity.DbContext
    {

    }
}
