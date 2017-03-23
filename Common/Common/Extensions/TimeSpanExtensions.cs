using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers;

namespace Common.Extensions
{
    public static class TimeSpanExtensions
    {
        public static string ToUserFriendlyString(this TimeSpan timeSpan, CultureInfo cultureInfo)
        {
            return TimeSpanHelper.Current.ConvertTimeSpanToUserFriendlyString(timeSpan, cultureInfo);
        }
    }
}
