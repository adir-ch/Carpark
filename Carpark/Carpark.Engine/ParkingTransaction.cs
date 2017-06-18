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

        public string Summary()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Parking transaction: ");
            builder.AppendFormat("{0}, ", _patron);
            builder.AppendFormat("Qulify for: {0}, ", _parkingRate.RateDescription());
            builder.AppendFormat("Total = ${0} AU", TransactionTotal());
            return builder.ToString(); 
        }
    }
}
