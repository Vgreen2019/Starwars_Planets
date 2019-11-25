using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarWarsApp.Models;
using static StarWarsApp.Models.StarWarsPlanetResponse;

namespace StarWarsApp.Services
{
    public class StarWarsService : IStarWarsService
    {
        //private const string _baseUrl = "https://swapi.co";

        public async Task<StarWarsPlanetResponse> SelectAllPlanets()
        {
            using (var httpClient = new HttpClient { BaseAddress = new Uri("https://swapi.co") })   //We can use _baseUrl instead of the actual string 
            {
                
                var result = await httpClient.GetStringAsync("/api/planets/");     
                return JsonConvert.DeserializeObject<StarWarsPlanetResponse>(result);
            }
        }

        public async Task<PlanetResponse> SelectAPlanet(string endPoint)
        {

            using (var httpClient = new HttpClient { BaseAddress = new Uri("https://swapi.co") })   //We can use _baseUrl instead of the actual string 
            {

                var result = await httpClient.GetStringAsync(endPoint);
                return JsonConvert.DeserializeObject<PlanetResponse>(result);
            }
        }

       
    }
}
