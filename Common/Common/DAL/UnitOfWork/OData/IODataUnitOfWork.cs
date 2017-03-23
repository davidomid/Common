using System.Threading.Tasks;
using Microsoft.OData.Client;

namespace Common.DAL.UnitOfWork.OData
{
    public interface IODataUnitOfWork<C> : IUnitOfWork where C : DataServiceContext
    {
        C Context { get; }
        new DataServiceResponse Save();
        Task<DataServiceResponse> SaveAsync();
    }
}