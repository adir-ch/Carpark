using Carpark.Engine.RateRepository.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.RateRepository.Rates
{
    public class NightRate : ParkingRateBase
    {
        public NightRate(IParkingRateCalaulator rateCalculator) : base(rateCalculator)
        {
        }

        public override string RateDescription()
        {
            return "Night Rate"; 
        }
    }
}
