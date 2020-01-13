using System;

namespace StarWarsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var apiHelper = new SWAPIHelper();
            var starShipData = apiHelper.GetStarShips().Result;
            int noOfPassengers = 100;
            var dataProcessor = new StartShipDataProcessor(starShipData);
            var result = dataProcessor.GetStartShipDetails(noOfPassengers);
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }
        }
    }
}
