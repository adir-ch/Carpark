using Carpark.Engine.RateRepository.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.RateRepository.Rates
{
    public class EarlyBirdRate : ParkingRateBase
    {
        public EarlyBirdRate(IParkingRateCalaulator rateCalculator)
            : base(rateCalculator)
        {
        }

        public override string RateDescription()
        {
            return "Early bird Rate";  // TODO: it would be nice to take this from the DB as well. 
        }
    }
}
