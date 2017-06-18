using Carpark.Engine.DecisionTree.Helpers;
using Carpark.Engine.RateRepository.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.DecisionTree
{
    public class ParkingRateDecisionTree
    {
        public static DecisionQueryNode GetParkingRateDecisionTree()
        {
            var tree =
                new DecisionQueryNode
                {
                    Title = "Qualify for weekend rate",
                    Test = (patron) => DateTimeHelper.IsWeekend(patron.EnterTime, patron.ExitTime),
                    Positive = new DecisionResultNode() { DecisionResult = ParkingRateCode.WeekendRate }, 
                    Negative = BuildNonWeekendSubTree()
                };

            return tree; 
        }

        private static DecisionNode BuildNonWeekendSubTree()
        {
            return new DecisionQueryNode
            {
                Title = "Qualify for night rate",
                Test = (patron) => DateTimeHelper.IsNight(patron.EnterTime, patron.ExitTime),
                Positive = new DecisionResultNode() { DecisionResult = ParkingRateCode.NightRate }, 
                Negative = BuildNonNightSubTree()
            };
        }

        private static DecisionNode BuildNonNightSubTree()
        {
            return new DecisionQueryNode
            {
                Title = "Qualify for early bird rate",
                Test = (patron) => DateTimeHelper.IsEarlyBird(patron.EnterTime, patron.ExitTime),
                Positive = new DecisionResultNode() { DecisionResult = ParkingRateCode.EarlyBird },
                Negative = BuildNonEarlyBirdSubTree()
            };
        }

        private static DecisionNode BuildNonEarlyBirdSubTree()
        {
            return new DecisionResultNode()
            {
                DecisionResult = ParkingRateCode.StandardHourRate
            };
        }

    }
}
