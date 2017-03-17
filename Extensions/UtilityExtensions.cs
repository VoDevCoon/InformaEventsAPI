using System;

namespace InformaEventsAPI.Extensions
{
    public static class UtilityExtensions
    {
        public static DateTime? UnixTimeStampToDateTime(this string timestamp)
        {
            double dTimeStamp;

            if(!string.IsNullOrEmpty(timestamp)&&Double.TryParse(timestamp, out dTimeStamp))
            {          
                return new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc).AddSeconds(dTimeStamp).ToLocalTime();
            }

            return null;
        }
    }
}