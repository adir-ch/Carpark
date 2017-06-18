using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carpark.Engine.RateRepository.Calculators
{
    public interface IParkingRateCalaulator
    {
        decimal CalculateRate(DateTime entryTime, DateTime exitTime); 
    }
}
