using Carpark.Engine.RateRepository;
using Carpark.Engine.RateRepository.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.DecisionTree
{
    public abstract class DecisionNode
    {
        public abstract ParkingRateCode Evaluate(Patron patron);
    }
}
