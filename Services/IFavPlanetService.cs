using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApp.Services
{
    public interface IFavPlanetService
    {
        FanFavViewModel SelectFanFavPlanets(int fanId);
        FanFavViewModel SelectFanFavPlanets();
        FanFavViewModel DeleteFavorite(string url);
        void SetFanID(int fanId);

    }
}

