using Carpark.Engine.RateRepository.Calculators;
using Carpark.Engine.RateRepository.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.ParkingRateRepository.Data
{
    public class DbDataSeed
    {
        public void SeedDb(DbContext db)
        {
            SeedRates(db);
        }

        private void SeedRates(DbContext db)
        {
            db.Create((int)ParkingRateCode.EarlyBird, (decimal)13.00);
            db.Create((int)ParkingRateCode.NightRate, (decimal)6.50);
            db.Create((int)ParkingRateCode.WeekendRate, (decimal)10.00);
            db.Create((int)ParkingRateCode.StandardHourRate, (decimal)5.00); 
            db.Create((int)ParkingRateCode.StandardCalendarDayRate, (decimal)20.00); 
        }
    }
}
