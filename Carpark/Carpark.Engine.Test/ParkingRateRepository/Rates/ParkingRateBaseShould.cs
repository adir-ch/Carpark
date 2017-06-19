using Carpark.Engine.RateRepository.Calculators;
using Carpark.Engine.RateRepository.Rates;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.Test.ParkingRateRepository.Rates
{
    [TestFixture]
    public class ParkingRateBaseShould
    {
        private NightRate _rate;
        private Mock<IParkingRateCalaulator> _calculator;
        private DateTime _enterTime;
        private DateTime _exitTime; 

        [OneTimeSetUp]
        public void Init()
        {
            _calculator = new Mock<IParkingRateCalaulator>(); 
            _rate = new NightRate(_calculator.Object);

            _enterTime = new DateTime(2017, 01, 01, 18, 0, 0);
            _exitTime = new DateTime(2017, 01, 02, 6, 00, 00);

            _calculator.Setup(calc => calc.CalculateRate(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(100); 
        }

        [Test]
        public void ReturnTotalParkingRateAmount()
        {
            var result = _rate.CalculateRate(_enterTime, _exitTime);
            Assert.That(result, Is.EqualTo(100)); 
            _calculator.Verify(f => f.CalculateRate(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Exactly(1)); 
        }
    }
}
