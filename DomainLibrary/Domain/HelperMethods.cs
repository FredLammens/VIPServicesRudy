using System;

namespace DomainLibrary.Domain
{
    static class HelperMethods
    {
        public static bool TimeInRange(DateTime dateTime, TimeSpan start, TimeSpan end)
        {
            TimeSpan date = dateTime.TimeOfDay; //convert dateTime to TimeSpan
            //See if start comes before end
            if (start < end)
                return start <= date && date <= end;
            //end comes before start
            return !(end < date && date < start);
        }
        public static int RoundtoFive(double i)
        {
            return (int)(Math.Round(i / 5) * 5);
        }
    }
}
