using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace Common.OData.Controllers
{
    public abstract class BaseODataController<T> : ODataController where T: class
    {
        public virtual IQueryable<T> Get()
        {
            throw new NotSupportedException("HTTP GET not supported for route: " + this.Request.RequestUri);
        }

        public virtual SingleResult<T> Get([FromODataUri] int key)
        {
            throw new NotSupportedException("HTTP GET by key not supported for route: " + this.Request.RequestUri);
        }

        public virtual Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<T> delta)
        {
            throw new NotSupportedException("HTTP PATCH not supported for route: " + this.Request.RequestUri);
        }

        public virtual Task<IHttpActionResult> Post(T entity)
        {
            throw new NotSupportedException("HTTP POST not supported for route: " + this.Request.RequestUri);
        }
    }
}