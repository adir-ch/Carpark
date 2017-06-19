using Carpark.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Client
{
    class Client
    {
        private ParkingEngine _engine = new ParkingEngine(); 

        static void Main(string[] args)
        {
            Client client = new Client();
            client.CalculateParkingRate(new DateTime(2017, 01, 01, 18, 0, 0), new DateTime(2017, 01, 02, 5, 59, 59)); // night rate 
            client.CalculateParkingRate(new DateTime(2017, 01, 02, 18, 0, 0), new DateTime(2017, 01, 01, 5, 59, 59)); // illegal input
            client.CalculateParkingRate(new DateTime(2017, 01, 01, 18, 0, 0), new DateTime(2017, 01, 04, 5, 59, 59)); // Weekend rate 
            client.CalculateParkingRate(new DateTime(2017, 06, 03, 1, 0, 0), new DateTime(2017, 06, 04, 5, 59, 59)); // Standard few days rate 
            client.CalculateParkingRate(new DateTime(2017, 01, 03, 06, 01, 00), new DateTime(2017, 01, 03, 16, 00, 00)); // Early bird
            client.CalculateParkingRate(new DateTime(2017, 06, 06, 1, 0, 0), new DateTime(2017, 06, 06, 1, 00, 01)); // Standard less than one hour
            client.CalculateParkingRate(new DateTime(2017, 06, 06, 1, 0, 0), new DateTime(2017, 06, 06, 1, 30, 00)); // Standard less than one hour
            client.CalculateParkingRate(new DateTime(2017, 06, 06, 1, 0, 0), new DateTime(2017, 06, 06, 2, 10, 00)); // Standard between one to two hours
            client.CalculateParkingRate(new DateTime(2017, 06, 06, 1, 0, 0), new DateTime(2017, 06, 06, 3, 10, 00)); // Standard between two to three hours
            client.CalculateParkingRate(new DateTime(2017, 06, 06, 1, 0, 0), new DateTime(2017, 06, 06, 4, 00, 01)); // Standard > three hours
            client.CalculateParkingRate(new DateTime(2017, 06, 06, 1, 0, 0), new DateTime(2017, 06, 06, 6, 00, 01)); // Standard > 5 hours
        }

        private void CalculateParkingRate(DateTime enter, DateTime exit)
        {
            Console.WriteLine("{0}----> New parking [enter: {1}, exit: {2}]", Environment.NewLine, enter, exit); 
            if(enter > exit)
            {
                Console.WriteLine("Invalid dates detected - cannot enter after exit!");
                return; 
            }

            var patron = new Patron() 
            {
                EnterTime = enter, ExitTime = exit
            };

            var transaction = _engine.CalculateParkingRate(patron);
            Console.WriteLine(transaction.Summary());
        }
    }
}
