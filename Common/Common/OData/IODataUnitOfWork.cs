using System;
using System.Threading.Tasks;
using Microsoft.OData.Client;

namespace Common.OData
{
    public interface IODataUnitOfWork<C> : IDisposable where C : DataServiceContext 
    {
        void Save();
        Task<DataServiceResponse> SaveAsync();
        C Context { get; }
    }
}
