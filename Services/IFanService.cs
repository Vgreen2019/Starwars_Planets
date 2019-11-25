using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApp.Services
{
    public interface IFanService
    {
        FansViewModel GetAllFans();
        FansViewModel AddNewFan(AddFanViewModel model);
        FanViewModel GetFanInfo(int fanId);
        void SetFanID(int fanId);
        void SetFavPlanetUrl(string favPlanetUrl);
        void AddFavoritePlanets();  //int FanId, string FavoritePlanetUrl

    }
}
