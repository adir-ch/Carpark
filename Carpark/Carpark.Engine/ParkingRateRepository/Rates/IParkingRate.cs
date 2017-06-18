using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.RateRepository.Rates
{
    public interface IParkingRate
    {
        string RateDescription();
        decimal CalculateRate(DateTime entryTime, DateTime exitTime); 
    }
}
