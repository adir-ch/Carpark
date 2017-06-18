using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.Test.Engine
{
    [TestFixture]
    public class ParkingEngineShould
    {
        private ParkingEngine _engine; 

        [OneTimeSetUp]
        public void Init()
        {
            _engine = new ParkingEngine(); 
        }

        [Test]
        public void CalculateTotalParkingCostOnValidNightRateEntries()
        {
            DateTime enter = new DateTime(2017, 01, 01, 18, 0, 0);
            DateTime exit = new DateTime(2017, 01, 02, 5, 59, 59);
            var transaction = _engine.CalculateParkingRate(new Patron() { EnterTime = enter, ExitTime = exit });
            Assert.That(transaction.TransactionTotal(), Is.EqualTo((decimal)6.5));  
        }
    }
}
