using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.OData.Client;

namespace Common.OData.Extensions
{
    public static class ODataDataServiceQueryExtensions
    {
        public static TSource FirstOrDefault<TSource>(this DataServiceQuery<TSource> dataServiceQuery, Expression<Func<TSource, bool>> predicate)
        {
            return dataServiceQuery.Where(predicate).FirstOrDefault();
        }

        public static TSource First<TSource>(this DataServiceQuery<TSource> dataServiceQuery, Expression<Func<TSource, bool>> predicate)
        {
            return dataServiceQuery.Where(predicate).First();
        }
    }
}
