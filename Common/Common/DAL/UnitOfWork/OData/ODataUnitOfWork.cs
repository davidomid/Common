using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DAL.Repository.OData;
using Common.OData;
using Microsoft.OData.Client;
using Newtonsoft.Json;

namespace Common.DAL.UnitOfWork.OData
{
    public class ODataUnitOfWork<C> : IODataUnitOfWork<C> where C : DataServiceContext

    {
        private readonly Dictionary<Type, IODataRepository> _genericRepositories =
            new Dictionary<Type, IODataRepository>();

        public ODataUnitOfWork(C context)
        {
            this.Context = context;
        }

        public DataServiceResponse Save()
        {
            try
            {
                return this.Context.SaveChanges();
            }
            catch (DataServiceRequestException dsre)
            {
                string error =
                    JsonConvert.DeserializeObject<ODataError>(dsre.InnerException?.Message).Error.InnerError.Message;
                throw new Exception(error);
            }
        }

        public async Task<DataServiceResponse> SaveAsync()
        {
            try
            {
                return await this.Context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DataServiceRequestException dsre)
            {
                string error =
                    JsonConvert.DeserializeObject<ODataError>(dsre.InnerException?.Message).Error.InnerError.Message;
                throw new Exception(error);
            }
        }

        public C Context { get; } // todo remove the reference to this. This will require a lot of refactoring.

        public void Dispose()
        {
        }

        void IUnitOfWork.Save()
        {
            throw new NotImplementedException();
        }

        public virtual IODataRepository<T> GetGenericRepository<T>() where T : BaseEntityType
        {
            if (this._genericRepositories.ContainsKey(typeof (T)))
            {
                return this._genericRepositories[typeof (T)] as IODataRepository<T>;
            }

            ODataRepository<T, C> repository = new ODataRepository<T, C>(this.Context);

            this._genericRepositories[typeof (T)] = repository;

            return repository;
        }
    }
}