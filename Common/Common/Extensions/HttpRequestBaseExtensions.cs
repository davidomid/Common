using System.Globalization;
using System.Web;
using Common.Helpers;

namespace Common.Extensions
{
    public static class HttpRequestBaseExtensions
    {
        public static CultureInfo GetUserCultureInfo(this HttpRequestBase httpRequestBase, CultureInfo defaultCulture)
        {
            return HttpRequestBaseHelper.Current.GetUserCultureInfo(httpRequestBase, defaultCulture);
        }
    }
}