using Carpark.Engine.RateRepository;
using Carpark.Engine.RateRepository.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine
{
    public class ParkingTransaction
    {
        private Patron _patron;
        private IParkingRate _parkingRate;

        public ParkingTransaction(Patron patron, IParkingRate parkingRate)
        {
            _patron = patron;
            _parkingRate = parkingRate; 
        }

        public decimal TransactionTotal()
        {
            return _parkingRate.CalculateRate(_patron.EnterTime, _patron.ExitTime); 
        }
    }
}
