using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.RateRepository.Calculators
{
    public class FlatRateCalculator : IParkingRateCalaulator
    {
        public decimal Rate { get; set; }

        public decimal CalculateRate(DateTime entryTime, DateTime exitTime)
        {
            return Rate; 
        }
    }
}
