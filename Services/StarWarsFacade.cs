using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWarsApp.DAL;
using StarWarsApp.Models;

namespace StarWarsApp.Services
{
    public class StarWarsFacade: IStarWarsFacade
    {
        private readonly IStarWarsService _starWarsService;

        public StarWarsFacade(IStarWarsService starWarsService)
        {
            _starWarsService = starWarsService;

        }

        public async Task<PlanetsViewModel> GetAllPlanets()
        {
            var results = await _starWarsService.SelectAllPlanets();

            var planetsViewModel = new PlanetsViewModel();
            planetsViewModel.Planets = new List<Planet>();

            foreach (var responsePlanet in results.Results)
            {
                var planet = new Planet();
                planet.Name = responsePlanet.Name;
                planet.Url = responsePlanet.Url;

                planetsViewModel.Planets.Add(planet);
            }



            return planetsViewModel;

        }

        public async Task<PlanetViewModel> GetAPlanet(string url)
        {
            var apiEnding = GetPlanetInfo(url);
            var results = await _starWarsService.SelectAPlanet(apiEnding);

            var planetViewModel = new PlanetViewModel
            {
                Climate = results.Climate,
                Created = results.Created,
                Diameter = results.Diameter,
                Edited = results.Edited,
                Films = results.Films,
                Gravity = results.Gravity,
                Name = results.Name,
                Orbital_Period = results.Orbital_Period,
                Population = results.Population,
                Residents = results.Residents,
                Rotation_Period = results.Rotation_Period,
                Surface_Water = results.Surface_Water,
                Terrain = results.Terrain,
                Url = results.Url
            };

            if (url == null)
            {
                planetViewModel.Message = "The planet has not been added to the favorite's list.";
            }
            else
            {
                planetViewModel.Message = "The planet has been added to the favorite's list.";
            }

            return planetViewModel;

        }

      

        private string GetPlanetInfo(string url)
        {
            string[] separator = { "https://swapi.co" };
            int count = 1;

            string[] strlist = url.Split(separator, count, StringSplitOptions.RemoveEmptyEntries);
                        
            return strlist[0];
        }

         
    }
}
