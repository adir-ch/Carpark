using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.DecisionTree.Helpers
{
    public static class DateTimeHelper
    {
        public static bool IsNight(DateTime enter, DateTime exit)
        {
            var span = (exit - enter);
            //Console.WriteLine("start: {0}, end: {1} => Days={2}, TotalDays={3}, hours: {4}", enter, exit, span.Days, span.TotalDays, span.Hours);

            if (span.Days == 0 && span.Hours < 12)
            {
                if (enter.Hour >= 18 && exit.Hour < 6)
                {
                    //Console.WriteLine("Found night rate");
                    return true;
                }
            }

            //Console.WriteLine("Not a night rate");
            return false; 
        }

        public static bool IsEarlyBird(DateTime enter, DateTime exit)
        {
            var sameDay = (exit.Date == enter.Date);
            DateTime startExit = new DateTime(exit.Year, exit.Month, exit.Day, 15, 30, 00);
            DateTime endExit = new DateTime(exit.Year, exit.Month, exit.Day, 23, 30, 00);
            //Console.WriteLine("start: {0}, end: {1} => same day: {2}", enter, exit, sameDay ? "Yes" : "No");

            if (sameDay == true)
            {
                if (enter.Hour >= 6 && enter.Hour < 9)
                {
                    if (exit >= startExit && exit < endExit)
                    {
                        //Console.WriteLine("Found Early bird rate");
                        return true;
                    }

                }
            }

            //Console.WriteLine("Not an early bird rate");
            return false; 
        }

        public static bool IsWeekend(DateTime enter, DateTime exit)
        {
            var span = (exit - enter);
            //Console.WriteLine("start: {0}, end: {1} => Days={2}, TotalDays={3}, hours: {4}", enter, exit, span.Days, span.TotalDays, span.Hours);


            if (span.Days < 2)
            {
                if (enter.DayOfWeek == DayOfWeek.Saturday || enter.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (exit.DayOfWeek == DayOfWeek.Saturday || exit.DayOfWeek == DayOfWeek.Sunday)
                    {
                        //Console.WriteLine("Found weekend rate");
                        return true;
                    }
                }
            }

            //Console.WriteLine("Not a weekend rate");
            return false; 
        }
    }
}
