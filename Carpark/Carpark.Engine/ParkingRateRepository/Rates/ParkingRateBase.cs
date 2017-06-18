using Carpark.Engine.RateRepository.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.RateRepository.Rates
{
    public abstract class ParkingRateBase : IParkingRate
    {
        private IParkingRateCalaulator _rateCalculator;
        private Calculators.IParkingRateCalaulator rateCalculator;
        public abstract string RateDescription();

        public ParkingRateBase(IParkingRateCalaulator rateCalculator)
        {
            _rateCalculator = rateCalculator; 
        }

        public decimal CalculateRate(DateTime entryTime, DateTime exitTime)
        {
            return _rateCalculator.CalculateRate(entryTime, exitTime); 
        }
    }
}
