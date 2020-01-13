using System;
using Xunit;
using StarWarsApp;
using StarWarsApp.Models;
using System.Collections.Generic;

namespace StarWarsApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetStarShipDetailPassingTests()
        {
            var starShips = new List<StarshipModel>();
            starShips.Add(new StarshipModel { Name = "Executor", Passengers = 38000, Pilots = new string[] { "" } });
            starShips.Add(new StarshipModel { Name = "Sentinel-class landing craft", Passengers = 75, Pilots = new string[] { "" } });
            starShips.Add(new StarshipModel { Name = "Millennium Falcon", Passengers = 6, Pilots = new string[] { "Chewbaca", "Pilot 2", "Pilot 3", "Pilot 4" } });
            starShips.Add(new StarshipModel { Name = "Slave 1", Passengers = 6, Pilots = new string[] { "Pilot 20" } });
            starShips.Add(new StarshipModel { Name = "Imperial shuttle", Passengers = 20, Pilots = new string[] { "" } });

            var dataProcessor = new StartShipDataProcessor(starShips);
            Assert.Equal(new string[] { "Millennium Falcon - Chewbaca" }, dataProcessor.GetStartShipDetails(5));
        }

        [Fact]
        public void GetStarShipDetailFor10PassingTests()
        {
            var starShips = new List<StarshipModel>();
            starShips.Add(new StarshipModel { Name = "Executor", Passengers = 38000, Pilots = new string[] { "" } });
            starShips.Add(new StarshipModel { Name = "Sentinel-class landing craft", Passengers = 75, Pilots = new string[] { "" } });
            starShips.Add(new StarshipModel { Name = "Millennium Falcon", Passengers = 6, Pilots = new string[] { "Chewbaca", "Pilot 2", "Pilot 3", "Pilot 4" } });
            starShips.Add(new StarshipModel { Name = "Slave 1", Passengers = 6, Pilots = new string[] { "Pilot 20" } });
            starShips.Add(new StarshipModel { Name = "Imperial shuttle", Passengers = 20, Pilots = new string[] { "" } });

            var dataProcessor = new StartShipDataProcessor(starShips);
            Assert.Equal(new string[] { "Millennium Falcon - Chewbaca", "Millennium Falcon - Pilot 2" }, dataProcessor.GetStartShipDetails(10));
        }

        [Fact]
        public void GetStarShipDetailFor100PassingTests()
        {
            var starShips = new List<StarshipModel>();
            starShips.Add(new StarshipModel { Name = "Executor", Passengers = 38000, Pilots = new string[0] });
            starShips.Add(new StarshipModel { Name = "Sentinel-class landing craft", Passengers = 75, Pilots = new string[0] });
            starShips.Add(new StarshipModel { Name = "Millennium Falcon", Passengers = 6, Pilots = new string[] { "Chewbaca", "Pilot 2", "Pilot 3", "Pilot 4" } });
            starShips.Add(new StarshipModel { Name = "Slave 1", Passengers = 6, Pilots = new string[] { "Pilot 20" } });
            starShips.Add(new StarshipModel { Name = "Imperial shuttle", Passengers = 20, Pilots = new string[] { "Pilot 40" } });

            var dataProcessor = new StartShipDataProcessor(starShips);
            var output = dataProcessor.GetStartShipDetails(100);
            Assert.Equal(new string[] {
                "Millennium Falcon - Chewbaca",
                "Millennium Falcon - Pilot 2",
                "Millennium Falcon - Pilot 3",
                "Millennium Falcon - Pilot 4",
                "Slave 1 - Pilot 20",
                "Imperial shuttle - Pilot 40"
            }, output);
        }
    }
}
