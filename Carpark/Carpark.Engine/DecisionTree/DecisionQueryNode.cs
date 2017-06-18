using Carpark.Engine.RateRepository;
using Carpark.Engine.RateRepository.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.DecisionTree
{
    public class DecisionQueryNode : DecisionNode
    {
        public string Title { get; set; }
        public DecisionNode Positive { get; set; }
        public DecisionNode Negative { get; set; }

        public Func<Patron, bool> Test { get; set; }

        public override ParkingRateCode Evaluate(Patron patron)
        {
            var result = Test(patron);
            Console.WriteLine("  - {0}? {1}", Title, result ? "yes" : "no");

            if(result == true)
            {
                return Positive.Evaluate(patron);
            }
            else
            {
                return Negative.Evaluate(patron); 
            }
        }
    }
}
