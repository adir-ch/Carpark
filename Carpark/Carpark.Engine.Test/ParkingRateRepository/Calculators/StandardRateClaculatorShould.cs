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
        public void ThrowExceptionOnIllegalRateSettings([Values(0, -100)] decimal hourRate,
                                                        [Values(-1, -100)] decimal dayRate)
            
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
                yield return new TestCaseData(new DateTime(2017, 06, 06, 1, 0, 0), 
                                              new DateTime(2017, 06, 06, 1, 30, 00)).Returns(5);

                yield return new TestCaseData(new DateTime(2017, 06, 06, 1, 0, 0), 
                                              new DateTime(2017, 06, 06, 2, 10, 00)).Returns(10);

                yield return new TestCaseData(new DateTime(2017, 06, 06, 1, 0, 0), 
                                              new DateTime(2017, 06, 06, 3, 10, 00)).Returns(15);
                
                yield return new TestCaseData(new DateTime(2017, 06, 06, 1, 0, 0), 
                                              new DateTime(2017, 06, 06, 4, 00, 01)).Returns(20);

                yield return new TestCaseData(new DateTime(2017, 06, 06, 1, 0, 0), 
                                              new DateTime(2017, 06, 06, 6, 00, 01)).Returns(20);
            }
        }
    }
}
