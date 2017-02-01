using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers;

namespace Common.Extensions
{
    public static class TimeSpanExtensions
    {
        public static string ToUserFriendlyString(this TimeSpan timeSpan)
        {
            return TimeSpanHelper.Current.ConvertTimeSpanToUserFriendlyString(timeSpan);
        }
    }
}
