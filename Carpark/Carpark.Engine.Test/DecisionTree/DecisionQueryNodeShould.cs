using Carpark.Engine.DecisionTree;
using Carpark.Engine.RateRepository.Rates;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.Test.DecisionTree
{
    [TestFixture]
    public class DecisionQueryNodeShould
    {
        DecisionQueryNode _node;

        [OneTimeSetUp]
        public void Init()
        {
            _node = new DecisionQueryNode() 
            {
                Title = "Test node", 
                Test = (patron) => patron.EnterTime < patron.ExitTime, // simple test case 
                Positive = new DecisionResultNode() { DecisionResult = ParkingRateCode.EarlyBird },
                Negative = new DecisionResultNode() { DecisionResult = ParkingRateCode.WeekendRate }
            }; 
        }

        [Test, TestCaseSource(typeof(SelectCorrectLegOnTestResultTestCases), "TestCases")]
        public ParkingRateCode SelectCorrectLegOnTestResult(Patron patron)
        {
            return _node.Evaluate(patron);
        }

        public class SelectCorrectLegOnTestResultTestCases
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(new Patron() 
                    { 
                        EnterTime = new DateTime(2017, 01, 01, 18, 0, 0), 
                        ExitTime = new DateTime(2017, 01, 02, 6, 00, 00) 
                    }).Returns(ParkingRateCode.EarlyBird);

                    yield return new TestCaseData(new Patron()
                    {
                        EnterTime = new DateTime(2017, 01, 02, 18, 0, 0),
                        ExitTime = new DateTime(2017, 01, 01, 6, 00, 00)
                    }).Returns(ParkingRateCode.WeekendRate);
                }
            }
        }
    }
}
