using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApp.DAL
{
    public interface IFanStore
    {
        IEnumerable<FanDALModel> SelectAllFans();
        FanDALModel GetFanInfo(int fanId);
        bool InsertNewFan(FanDALModel dalModel);
        bool InsertFavPlanet(int fanId, string favPlanet);

    }
}
