using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Humanizer;
using Humanizer.Localisation;

namespace Common.Helpers
{
    public class TimeSpanHelper
    {
        public static TimeSpanHelper Current = new TimeSpanHelper();

        /// <summary>
        ///     Constructs a user-friendly string for this TimeSpan instance.
        /// </summary>
        public string ConvertTimeSpanToUserFriendlyString(TimeSpan timeSpan, CultureInfo cultureInfo)
        {
            string userFriendlyString = timeSpan.Humanize(precision:int.MaxValue, maxUnit:TimeUnit.Year, minUnit:TimeUnit.Millisecond, culture: cultureInfo);
            return userFriendlyString;
        }

        /// <summary>
        ///     Constructs a string description of a time-span value.
        /// </summary>
        /// <param name="value">The value of this item</param>
        /// <param name="description">The name of this item (singular form)</param>
        private static string CreateValueString(int value, string description)
        {
            return string.Format("{0:#,##0} {1}",
                value, (value == 1) ? description : string.Format("{0}s", description));
        }
    }
}