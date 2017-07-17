using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadarshoAnalyticsDotNetFramework.Utility
{
    public static class Dateutils
    {
        public static long ToUnixTime(this DateTime dateTime)
        {
            return (long)(TimeZoneInfo.ConvertTimeToUtc(dateTime) -
          new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
        }
    }
}