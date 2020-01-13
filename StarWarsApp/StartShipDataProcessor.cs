using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarWarsApp
{
    public class StartShipDataProcessor
    {
        private readonly List<StarshipModel> _starShips;
        public StartShipDataProcessor(List<StarshipModel> starShips)
        {
            _starShips = starShips;
        }

        public string[] GetStartShipDetails(int noOfPassengers)
        {
            var sortedList = _starShips.Where(w => w.Pilots.Length > 0 && w.Passengers > 0).OrderBy(o => o.Passengers).ToArray();
            int i = 0, remainingPassengers = noOfPassengers;
            List<string> result = new List<string>();
            while (true)
            {
                var isLast = false;
                foreach (var pilot in sortedList[i].Pilots)
                {
                    result.Add($"{sortedList[i].Name} - {pilot}");
                    if (sortedList[i].Passengers <= remainingPassengers)
                    {
                        remainingPassengers = remainingPassengers - sortedList[i].Passengers;
                    }
                    else
                    {
                        isLast = true;
                        break;
                    }
                }
                i++;
                if (remainingPassengers <= 0 || i >= sortedList.Length || isLast)
                    break;
            }
            return result.ToArray();
        }
    }
}
