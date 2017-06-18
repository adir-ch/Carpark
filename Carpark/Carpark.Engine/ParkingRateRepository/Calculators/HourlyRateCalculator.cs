using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.RateRepository.Calculators
{
    public class HourlyRateCalculator : IParkingRateCalaulator
    {
        public decimal HourRate { get; set; }
        public decimal CalendarDayRate { get; set; }

        public decimal CalculateRate(DateTime entryTime, DateTime exitTime)
        {
            var timespan = (exitTime - entryTime); 

            if (timespan.Days > 1)
            {
                return (timespan.Days * CalendarDayRate); 
            }

            return (timespan.Hours * HourRate); 
        }
    }
}
