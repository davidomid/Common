using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.OData.Client;

namespace Common.DAL.Repository.OData
{
    public interface IODataRepository<T> : IODataRepository, IRepository<T> where T : BaseEntityType
    {
        new DataServiceQuery<T> Get();
    }
}