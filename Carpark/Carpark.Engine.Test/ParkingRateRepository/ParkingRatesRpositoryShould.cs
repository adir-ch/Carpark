using Carpark.Engine.ParkingRateRepository;
using Carpark.Engine.RateRepository.Rates;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.Test.ParkingRateRepository
{
    [TestFixture]
    public class ParkingRatesRpositoryShould
    {
        private ParkingRatesRepository _repo; 

        [OneTimeSetUp]
        public void Init()
        {
            _repo = new ParkingRatesRepository(); 
        }

        [Test]
        [TestCase(ParkingRateCode.EarlyBird, ExpectedResult=typeof(EarlyBirdRate))]
        [TestCase(ParkingRateCode.WeekendRate, ExpectedResult = typeof(WeekendRate))]
        [TestCase(ParkingRateCode.NightRate, ExpectedResult = typeof(NightRate))]
        [TestCase(ParkingRateCode.StandardHourRate, ExpectedResult = typeof(StandardRate))]
        [TestCase(ParkingRateCode.StandardCalendarDayRate, ExpectedResult = typeof(StandardRate))]
        public Type ReturnCorrectParkingObjectByCode(ParkingRateCode code)
        {
            var rate = _repo.GetParkingRate(code);
            return rate.GetType();  
        }

        [Test]
        public void ThrowExceptionOnIllegalRateCode([Values(100, 200, 300)] int code)
        {
            Assert.Throws<Exception>(() => { _repo.GetParkingRate((ParkingRateCode)code); });
        }

    }
}
