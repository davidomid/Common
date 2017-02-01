using System;
using System.Threading.Tasks;
using Microsoft.OData.Client;
using Newtonsoft.Json;

namespace Common.OData
{
    public class ODataUnitOfWork<C> : IODataUnitOfWork<C> where C : DataServiceContext  
  
    {
        public ODataUnitOfWork(C context)
        {
            this.Context = context;
        } 

        public void Dispose()
        {
            
        }

        public void Save()
        {
            this.SaveAsync().Wait();
        }

        public async Task<DataServiceResponse> SaveAsync()
        {
            try
            {
                return await Context.SaveChangesAsync().ConfigureAwait(continueOnCapturedContext: false);
            }
            catch (DataServiceRequestException dsre)
            {
                string error = JsonConvert.DeserializeObject<ODataError>(dsre.InnerException.Message).Error.InnerError.Message;
                throw new Exception(error);
            }
        }

        public C Context { get; }
    }
}