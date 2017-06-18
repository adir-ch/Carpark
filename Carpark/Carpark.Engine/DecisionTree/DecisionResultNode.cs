using Carpark.Engine.RateRepository;
using Carpark.Engine.RateRepository.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carpark.Engine.ParkingRateRepository.Helpers;

namespace Carpark.Engine.DecisionTree
{
    public class DecisionResultNode : DecisionNode
    {
        public ParkingRateCode DecisionResult { get; set; }
        public override ParkingRateCode Evaluate(Patron patron)
        {
            Console.WriteLine("Reached a decision: {0}", typeof(ParkingRateCode).GetEnumDescription((int?)DecisionResult));
            return DecisionResult; 
        }
    }
}
