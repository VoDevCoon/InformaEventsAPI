using System;

namespace InformaEventsAPI.Extensions
{
    public static class UtilityExtensions
    {
        public static DateTime? UnixTimeStampToDateTime(this string timestamp)
        {
            double dTimeStamp;
            DateTime eventStartDate;

            if(!string.IsNullOrEmpty(timestamp)&&Double.TryParse(timestamp, out dTimeStamp))
            {
                eventStartDate = new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc).AddSeconds(dTimeStamp).ToLocalTime();
                if(eventStartDate.CompareTo(DateTime.Now)<0)
                {
                    eventStartDate = new DateTime(2100,1,1);
                }
            }
            else{
                eventStartDate = new DateTime(2100,1,1);
            }

            return eventStartDate;
        }
    }
}