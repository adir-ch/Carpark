using Carpark.Engine.RateRepository.Calculators;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.Test.ParkingRateRepository.Calculators
{
    [TestFixture]
    public class StandardRateClaculatorShould
    {
        private StandardRateCalculator _calculator;

        [OneTimeSetUp]
        public void Init()
        {
            _calculator = new StandardRateCalculator(); 
        }

        [Test, TestCaseSource(typeof(CalculateStandardRateAccordingToInitializedRateTestCases), "TestCases")]
        public decimal CalculateStandardRateAccordingToInitializedRate(DateTime enterTime, DateTime exitTime)
        {
            _calculator.HourRate = (decimal) 5.0; 
            _calculator.CalendarDayRate = (decimal) 20.0; 
            return _calculator.CalculateRate(enterTime, exitTime); 
        }

        [Test]
        public void ThrowExceptionOnIllegalRateSettings([Values(0, 100, -100)] decimal hourRate,
                                                        [Values(100, -1, -100)] decimal dayRate)
            
        {
            _calculator.HourRate = hourRate; 
            _calculator.CalendarDayRate = dayRate;
            Assert.Throws<Exception>(() => { _calculator.CalculateRate(It.IsAny<DateTime>(), It.IsAny<DateTime>()); });
        }
    }

    public class CalculateStandardRateAccordingToInitializedRateTestCases
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new DateTime(2017, 01, 01, 18, 0, 0), 
                                              new DateTime(2017, 01, 02, 6, 00, 00)).Returns(0);

                yield return new TestCaseData(new DateTime(2017, 01, 01, 18, 0, 0), 
                                              new DateTime(2017, 01, 02, 5, 59, 59)).Returns(0);
                
                yield return new TestCaseData(new DateTime(2017, 01, 01, 17, 59, 59), 
                                              new DateTime(2017, 01, 02, 5, 00, 00)).Returns(0);
            }
        }
    }
}
