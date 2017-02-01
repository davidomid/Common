using System.Globalization;
using System.Linq;
using System.Web;

namespace Common.Helpers
{
    public class HttpRequestBaseHelper
    {
        public static HttpRequestBaseHelper Current = new HttpRequestBaseHelper();

        public CultureInfo GetUserCultureInfo(HttpRequestBase httpRequestBase, CultureInfo defaultCulture)
        {
            // Get Browser languages.
            string[] userLanguages = httpRequestBase.UserLanguages;
            CultureInfo userCulture;
            if (userLanguages != null && userLanguages.Any())
            {
                try
                {
                    userCulture = new CultureInfo(userLanguages.First());
                }
                catch (CultureNotFoundException)
                {
                    userCulture = defaultCulture;
                }
            }
            else
            {
                userCulture = defaultCulture;
            }
            // Here CultureInfo should already be set to either user's prefereable language
            // or to InvariantCulture if user transmitted invalid culture ID.
            return userCulture;
        }
    }
}
