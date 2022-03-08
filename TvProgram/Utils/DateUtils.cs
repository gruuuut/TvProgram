using System;

namespace TvProgram.Utils
{
    static class DateUtils
    {
        public static string SuffixNow()
        {
            return string.Concat(DateTime.Now.Year,
                                DateTime.Now.Month.ToString().PadLeft(2, '0'),
                                DateTime.Now.Day.ToString().PadLeft(2, '0'),
                                "_",
                                DateTime.Now.Hour.ToString().PadLeft(2, '0'),
                                DateTime.Now.Minute.ToString().PadLeft(2, '0'),
                                DateTime.Now.Second.ToString().PadLeft(2, '0'));
        }
    }
}
