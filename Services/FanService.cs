using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWarsApp.DAL;
using StarWarsApp.Models;

namespace StarWarsApp.Services
{
    public class FanService: IFanService
    {
        private readonly IFanStore _fanStore;
        public int FanID { get; set; }
        public string FavoritePlanetUrl { get; set; }

        public FanService(IFanStore fanStore)
        {
            _fanStore = fanStore;
        }

        public void SetFanID(int fanId)
        {
            FanID = fanId;
        }

        public void SetFavPlanetUrl(string favPlanetUrl)
        {
            FavoritePlanetUrl = favPlanetUrl;
        }

        public void AddFavoritePlanets()
        {
            _fanStore.InsertFavPlanet(FanID, FavoritePlanetUrl);

        }

        public FansViewModel GetAllFans()
        {
            var dalFans = _fanStore.SelectAllFans();
            return MapDALToViewModel(dalFans);
        }

        public FansViewModel AddNewFan(AddFanViewModel model)
        {
            var dalModel = new FanDALModel
            {
                FanName = model.FanName
            };

            _fanStore.InsertNewFan(dalModel);

            var dalFans = _fanStore.SelectAllFans();
           
            return MapDALToViewModel(dalFans);
        }

       

        private static FansViewModel MapDALToViewModel(IEnumerable<DAL.FanDALModel> dalFans)
        {
            var fans = new List<Fan>();

            foreach (var dalFan in dalFans)
            {
               var fan = new Fan();
                fan.FanId = dalFan.FanId;
                fan.FanName = dalFan.FanName;

                fans.Add(fan);
            }

            var fansViewModel = new FansViewModel();
            fansViewModel.Fans = fans;

            return fansViewModel;
        }
                

        public FanViewModel GetFanInfo(int fanId)
        {
            var dalFan = _fanStore.GetFanInfo(fanId);

            var fanViewModel = new FanViewModel
            {
                FanName = dalFan.FanName
            };

            return fanViewModel;
        }
    }
}
