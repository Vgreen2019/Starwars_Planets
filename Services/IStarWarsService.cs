using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StarWarsApp.Models.StarWarsPlanetResponse;

namespace StarWarsApp.Services
{
    public interface IStarWarsService
    {
        Task<StarWarsPlanetResponse> SelectAllPlanets();
        Task<PlanetResponse> SelectAPlanet(string url);

    }
}
