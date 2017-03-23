using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.OData.Client;

namespace Common.DAL.Repository.OData
{
    public class ODataRepository<T, C> : IODataRepository<T> where T : BaseEntityType where C : DataServiceContext
    {
        private readonly C _context;
        private readonly DataServiceQuery<T> _dataServiceQuery;
        private readonly string _entitySetName;

        public ODataRepository(C context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            PropertyInfo dataServiceQueryProperty =
                typeof (C).GetProperties().FirstOrDefault(p => p.PropertyType == typeof (DataServiceQuery<T>));
            DataServiceQuery<T> dataServiceQuery = dataServiceQueryProperty?.GetValue(context) as DataServiceQuery<T>;

            if (dataServiceQuery == null)
            {
                throw new NotSupportedException(
                    string.Format("DataServiceContext type {0} does not support queries for entity type {1}",
                        typeof (C).FullName, typeof (T).FullName));
            }
            this._dataServiceQuery = dataServiceQuery;
            this._context = context;
            OriginalNameAttribute originalNameAttribute =
                (OriginalNameAttribute)
                    dataServiceQueryProperty.GetCustomAttributes(typeof (OriginalNameAttribute), true).SingleOrDefault();
            this._entitySetName = originalNameAttribute?.OriginalName;
        }

        //public T FindByKey(params KeyValuePair<string, object>[] keyValues)
        //{
        //    Dictionary<string, object> keyValuesDictionary = keyValues.ToDictionary(k => k.Key, v => v.Value);
        //    return this.FindByKey(keyValuesDictionary);
        //}

        //public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        //{
        //    return this._dataServiceQuery.Where(predicate);
        //}

        //public virtual T FindByKey(Dictionary<string, object> keyValues)
        //{
        //    DataServiceQuerySingle<T> querySingle = new DataServiceQuerySingle<T>(this._context, this._dataServiceQuery.GetKeyPath(Microsoft.OData.Client.Serializer.GetKeyString(this._context, keyValues)));
        //    return querySingle.GetValue();
        //}

        public DataServiceQuery<T> Get()
        {
            return this._dataServiceQuery;
        }

        IEnumerable<T> IRepository<T>.Get()
        {
            return this.Get();
        }

        public virtual void Add(T entity)
        {
            this._context.AddObject(this._entitySetName, entity);
        }

        public virtual void Remove(T entity)
        {
            this._context.DeleteObject(entity);
        }

        public virtual void Update(T entity)
        {
            this._context.AddObject(this._entitySetName, entity);
        }

    }
}