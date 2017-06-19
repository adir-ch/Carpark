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
    public class DecisionResultNodeShould
    {
        private Patron _patron; 

        [OneTimeSetUp]
        public void Init()
        {
            _patron = new Patron()
                        {
                            EnterTime = new DateTime(2017, 01, 01, 18, 0, 0),
                            ExitTime = new DateTime(2017, 01, 02, 6, 00, 00)
                        }; 
        }

        [Test, TestCaseSource(typeof(SelectCorrectLegOnTestResultTestCases), "TestCases")]
        public ParkingRateCode ReturnCorrectDecisionResult(DecisionResultNode node)
        {
            return node.Evaluate(_patron);
        }

        public class SelectCorrectLegOnTestResultTestCases
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(
                        new DecisionResultNode() 
                        { 
                            DecisionResult = ParkingRateCode.WeekendRate 
                        }).Returns(ParkingRateCode.WeekendRate);

                    yield return new TestCaseData(
                        new DecisionResultNode()
                        {
                            DecisionResult = ParkingRateCode.EarlyBird
                        }).Returns(ParkingRateCode.EarlyBird);

                }
            }
        }
    }
}
