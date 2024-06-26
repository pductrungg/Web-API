using System.Globalization;

namespace Dpoint.BackEnd.Checkin.Common.Helppers
{
    public static class DateTimeHelper
    {
        public const string DEFAULT_DATE_FORMAT = "yyyy-MM-dd";

        public const string DEFAULT_DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        public const string DEFAULT_DATETIME_WITHOUT_SECOND_FORMAT = "yyyy-MM-dd HH:mm";

        public static bool TryParseDateTime(this string strDateTime, out DateTime datetime, string exactFormat = null)
        {
            datetime = DateTime.MinValue;
            if (!string.IsNullOrEmpty(strDateTime))
            {
                string format = !string.IsNullOrEmpty(exactFormat) ? exactFormat : "yyyy-MM-dd";
                return DateTime.TryParseExact(strDateTime, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime);
            }

            return false;
        }       
       
    }
}
