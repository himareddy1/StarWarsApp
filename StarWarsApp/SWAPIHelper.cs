using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsApp
{
    class SWAPIHelper : IDisposable
    {
        private readonly HttpClient _apiClient;
        private const string STARSHIPS_REQUEST = "https://swapi.co/api/starships";

        public SWAPIHelper()
        {
            _apiClient = new HttpClient();
        }

        internal async Task<List<StarshipModel>> GetStarShips()
        {
            var data = await _apiClient.GetAsync(STARSHIPS_REQUEST);
            var httpData = await data.Content.ReadAsStringAsync();
            var rawJsonData = JsonConvert.DeserializeObject<JObject>(httpData);
            var starShipsJson = rawJsonData.SelectToken("results").ToString();
            var starShips = JsonConvert.DeserializeObject<List<StarshipModel>>(starShipsJson);
            foreach (var startShip in starShips)
            {
                for (int i = 0; i < startShip.Pilots.Length; i++)
                {
                    startShip.Pilots[i] = await GetStarShipPilotName(startShip.Pilots[i]);
                }
            }

            return starShips;
        }

        private async Task<string> GetStarShipPilotName(string pilotURI)
        {
            var data = await _apiClient.GetAsync(pilotURI);
            var httpData = await data.Content.ReadAsStringAsync();
            var rawJsonData = JsonConvert.DeserializeObject<JObject>(httpData);
            return rawJsonData.SelectToken("name").Value<string>();
        }

        public void Dispose()
        {
            _apiClient.Dispose();
        }
    }
}