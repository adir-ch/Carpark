using Carpark.Engine.DecisionTree;
using Carpark.Engine.ParkingRateRepository;
using Carpark.Engine.RateRepository.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine
{
    public class ParkingEngine
    {
        private ParkingRatesRepository _repository;
        private DecisionQueryNode _parkingRateDecisionTree; 

        public ParkingEngine()
        {
            _repository = new ParkingRatesRepository();
            _parkingRateDecisionTree = ParkingRateDecisionTree.GetParkingRateDecisionTree();  
        }

        public ParkingTransaction CalculateParkingRate(Patron patron)
        {
            ParkingRateCode parkingRateCode = _parkingRateDecisionTree.Evaluate(patron);
            var rate = _repository.GetParkingRate(parkingRateCode);

            return new ParkingTransaction(patron, rate); 
        }

    }
}
