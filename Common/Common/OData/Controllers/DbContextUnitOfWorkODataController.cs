using System;
using Common.DAL.UnitOfWork;

namespace Common.OData.Controllers
{
    public abstract class DbContextUnitOfWorkODataController<U, T> : BaseODataController<T> where T : class where U : IDbContextUnitOfWork
    {
        protected DbContextUnitOfWorkODataController(U dbContextUnitOfWork)
        {
            this.DbContextUnitOfWork = dbContextUnitOfWork;
        }

        protected DbContextUnitOfWorkODataController()
        {
            throw new NotImplementedException("Parameterless constructor not implemented.");
        }

        protected U DbContextUnitOfWork { get; set; }

        protected override void Dispose(bool disposing)
        {
            this.DbContextUnitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}