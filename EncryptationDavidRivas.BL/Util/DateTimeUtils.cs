using System;

namespace EncryptationDavidRivas.BL.Util
{
    public static class DateTimeUtils
    {
        public static string ToGeneralFormatString(this DateTime dateTime)
        {
            return dateTime == null ? string.Empty : dateTime.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}
