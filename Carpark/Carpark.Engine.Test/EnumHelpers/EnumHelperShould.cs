using Carpark.Engine.RateRepository.Rates;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carpark.Engine.ParkingRateRepository.Helpers; 

namespace Carpark.Engine.Test
{
    [TestFixture]
    public class EnumHelperShould
    {
        [Test]
        [TestCase(ParkingRateCode.EarlyBird, ExpectedResult = "Early bird rate")]
        [TestCase(ParkingRateCode.StandardHourRate, ExpectedResult = "Standard rate")]
        [TestCase(ParkingRateCode.StandardCalendarDayRate, ExpectedResult = "Standard rate")]
        public string RetriveDisplayAttribute(ParkingRateCode code)
        {
            return typeof(ParkingRateCode).GetEnumDescription((int?)code); 
        }
    }
}
