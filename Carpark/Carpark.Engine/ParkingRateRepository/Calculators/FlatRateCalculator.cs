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
            if (Rate <= 0)
            {
                throw new Exception(String.Format("Illegal parking rate found: {0}", Rate)); 
            }

            return Rate; 
        }
    }
}
