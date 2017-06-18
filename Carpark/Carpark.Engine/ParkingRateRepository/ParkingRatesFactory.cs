using Carpark.Engine.ParkingRateRepository.Data;
using Carpark.Engine.RateRepository;
using Carpark.Engine.RateRepository.Calculators;
using Carpark.Engine.RateRepository.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.ParkingRateRepository
{
    public class ParkingRatesFactory
    {
        // implementing some kind of caching since Parking rate does not need to be 
        // created every time (for a specific paking rate)
        private IDictionary<ParkingRateCode, IParkingRate> _parkingRatesMap;
        private DbContext _db = DbContext.Instance; 

        public ParkingRatesFactory()
        {
            _parkingRatesMap = new Dictionary<ParkingRateCode, IParkingRate>();
        }

        // created the function as virtual to have an extension point without overriding the 
        // entire class implementation, only the location creation method. 
        public virtual IParkingRate CreateParkingRate(ParkingRateCode parkingRateCode)
        {
            IParkingRate parkingRate = RetriveExistingParkingRate(parkingRateCode);
            if (parkingRate != null)
            {
                return parkingRate; 
            }

            parkingRate = GenerateParkingRateObject(parkingRateCode);
            AddCreatedParkingRate(parkingRateCode, parkingRate); 
            return parkingRate; 
        }

        private IParkingRate RetriveExistingParkingRate(ParkingRateCode parkingRateCode)
        {
            IParkingRate parkingRate; 
            _parkingRatesMap.TryGetValue(parkingRateCode, out parkingRate);
            return parkingRate; 
        }

        private void AddCreatedParkingRate(ParkingRateCode parkingRateCode, IParkingRate parkingRateObject)
        {
            _parkingRatesMap.Add(parkingRateCode, parkingRateObject); // add for next time
        }

        protected virtual IParkingRate GenerateParkingRateObject(ParkingRateCode parkingRateCode)
        {
            IParkingRate parkingRate = null; 
            switch (parkingRateCode)
            {
                case ParkingRateCode.EarlyBird:
                    {
                        parkingRate = CreateEarlyBirdRateObject(); 
                        break;
                    }
                case ParkingRateCode.NightRate:
                    {
                        parkingRate = CreateNightRateObject();

                        break;
                    }
                case ParkingRateCode.WeekendRate:
                    {
                        parkingRate = CreateWeekendRateObject();
                        break;
                    }
                case ParkingRateCode.StandardHourRate:
                case ParkingRateCode.StandardCalendarDayRate:
                    {
                        parkingRate = CreateStandardRateObject(); 
                        break;
                    }
                default:
                    {
                        parkingRate = CreateStandardRateObject(); 
                        break;
                    }
            }

            return parkingRate; 
        }

        private IParkingRate CreateEarlyBirdRateObject()
        {
            return new EarlyBirdRate(new FlatRateCalculator()
            {
                Rate = _db.Read((int)ParkingRateCode.EarlyBird)
            });
        }

        private IParkingRate CreateNightRateObject()
        {
            return new NightRate(new FlatRateCalculator()
            {
                Rate = _db.Read((int)ParkingRateCode.NightRate)
            });
        }

        private IParkingRate CreateWeekendRateObject()
        {
            return new WeekendRate(new FlatRateCalculator()
            {
                Rate = _db.Read((int)ParkingRateCode.WeekendRate)
            });
        }

        private IParkingRate CreateStandardRateObject()
        {
            return new StandardRate(new HourlyRateCalculator()
            {
                HourRate = _db.Read((int)ParkingRateCode.StandardHourRate),
                CalendarDayRate = _db.Read((int)ParkingRateCode.StandardCalendarDayRate)
            });
        }
    }
}
