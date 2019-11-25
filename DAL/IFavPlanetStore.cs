using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApp.DAL
{
    public interface IFavPlanetStore
    {
        IEnumerable<FavPlanetDALModel> SelectFanFavPlanets(int fanId);
        bool DeleteFavorite(string url, int fanId);



    }
}

