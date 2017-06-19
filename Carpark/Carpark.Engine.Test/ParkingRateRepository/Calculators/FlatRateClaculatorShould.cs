using Carpark.Engine.RateRepository.Calculators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.Test.ParkingRateRepository.Calculators
{
    [TestFixture]
    public class FlatRateClaculatorShould
    {
        private FlatRateCalculator _calculator;
        private DateTime _enterTime;
        private DateTime _exitTime;

        [OneTimeSetUp]
        public void Init()
        {
            _calculator = new FlatRateCalculator(); 
            _enterTime = new DateTime(2017, 01, 01, 18, 0, 0);
            _exitTime = new DateTime(2017, 01, 02, 6, 00, 00);
        }

        [Test]
        [TestCase(200000, ExpectedResult = 200000)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(18201, ExpectedResult = 18201)]
        public decimal CalculateFlatRateAccordingToInitializedRate(decimal rate)
        {
            _calculator.Rate = rate;
            return _calculator.CalculateRate(_enterTime, _exitTime); 
        }

        [Test]
        public void ThrowExceptionOnIllegalRateSettings([Values(0, -1, -100)] decimal rate)
        {
            _calculator.Rate = rate;
            Assert.Throws<Exception>(() => { _calculator.CalculateRate(_enterTime, _exitTime); });
        }
    }
}
