using System;
using System.Globalization;

namespace Utilities
{
    public static class DateTimeParser
    {
        public static System.DateTime ParseDateTime(string dateSubstring, string timeSubstring)
        {
            if (string.IsNullOrEmpty(dateSubstring))
            {
                throw new ArgumentNullException("Date string cannot be null or empty", nameof(dateSubstring));
            }

            if (string.IsNullOrEmpty(timeSubstring))
            {
                throw new ArgumentNullException("Time string cannot be null or empty", nameof(timeSubstring));
            }

            var date = ParseDate(dateSubstring);
            var time = ParseTime(timeSubstring);
            return date.Add(time);
        }

        public static System.DateTime ParseDate(string dateString)
        {
            System.DateTime date;
            var formats = new string[] { "yyMMdd", "yyyyMMdd" }; // add more formats here as needed

            if (System.DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date;
            }

            throw new ArgumentException($"Invalid date string: {dateString}", nameof(dateString));
        }

        public static TimeSpan ParseTime(string timeString)
        {
            // Add leading zeros to the time string as necessary
            timeString = timeString.PadLeft(6, '0');

            var formats = new string[] { "Hmmss", "HHmmss", "hmmss", "hhmmss" }; // add more formats here as needed

            if (TimeSpan.TryParseExact(timeString, formats, CultureInfo.InvariantCulture, 0, out TimeSpan time))
            {
                return time;
            }

            throw new ArgumentException($"Invalid time string: {timeString}", nameof(timeString));
        }
    }


}
