using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helpers
{
    public class TimeSpanHelper
    {
        public static TimeSpanHelper Current = new TimeSpanHelper();

        /// <summary>
        ///     Constructs a user-friendly string for this TimeSpan instance.
        /// </summary>
        public string ConvertTimeSpanToUserFriendlyString(TimeSpan timeSpan)
        {
            const int daysInYear = 365;
            const int daysInMonth = 30;

            // Get each non-zero value from TimeSpan component
            List<string> values = new List<string>();

            // Number of years
            int days = timeSpan.Days;
            if (days >= daysInYear)
            {
                int years = (days/daysInYear);
                values.Add(CreateValueString(years, "year"));
                days = (days%daysInYear);
            }
            // Number of months
            if (days >= daysInMonth)
            {
                int months = (days/daysInMonth);
                values.Add(CreateValueString(months, "month"));
                days = (days%daysInMonth);
            }
            // Number of days
            if (days >= 1)
                values.Add(CreateValueString(days, "day"));
            // Number of hours
            if (timeSpan.Hours >= 1)
                values.Add(CreateValueString(timeSpan.Hours, "hour"));
            // Number of minutes
            if (timeSpan.Minutes >= 1)
                values.Add(CreateValueString(timeSpan.Minutes, "minute"));
            // Number of seconds
            if (timeSpan.Seconds >= 1)
                values.Add(CreateValueString(timeSpan.Seconds, "second"));
            // Number of milliseconds (include when 0 if no other components included)
            if (timeSpan.Milliseconds >= 1 || values.Count == 0)
                values.Add(CreateValueString(timeSpan.Milliseconds, "millisecond"));

            // Combine values into string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < values.Count; i++)
            {
                if (builder.Length > 0)
                    builder.Append((i == (values.Count - 1)) ? " and " : ", ");
                builder.Append(values[i]);
            }
            // Return result
            return builder.ToString();
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