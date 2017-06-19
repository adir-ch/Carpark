using Carpark.Engine.RateRepository.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.ParkingRateRepository
{
    public class ParkingRatesRepository
    {
        private ParkingRatesFactory _parkingRatesFactory;

        public ParkingRatesRepository()
        {
            _parkingRatesFactory = new ParkingRatesFactory(); 
        }

        public IParkingRate GetParkingRate(ParkingRateCode parkingRateCode)
        {
            if (Enum.IsDefined(typeof(ParkingRateCode), parkingRateCode) == false)
            {
                throw new Exception(String.Format("Unable to create a new parking rate with code: {0}", parkingRateCode)); 
            }

            return _parkingRatesFactory.CreateParkingRate(parkingRateCode); 
        }

    }
}
