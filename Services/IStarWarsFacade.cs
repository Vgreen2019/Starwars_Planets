using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApp.Services
{
    public interface IStarWarsFacade
    {
        Task<PlanetsViewModel> GetAllPlanets();
        Task<PlanetViewModel> GetAPlanet(string url);


    }
}
