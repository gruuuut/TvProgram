using System;

namespace TvProgram.Utils
{
    static class DateUtils
    {
        /// <summary>
        /// Convertit un Unix time stamp en DateTime. Si la conversion n'est pas possible, renvoie la référence null.
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(string unixTimeStamp)
        {
            double result;
            if (double.TryParse(unixTimeStamp.ToString(), out result))
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(result).ToLocalTime();
                return dateTime;
            }
            else
            {
                return null;
            }                
        }
    }
}
