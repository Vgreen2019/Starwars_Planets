using StarWarsApp.DAL;
using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApp.Services
{
    public class FavPlanetService: IFavPlanetService
    {
        private readonly IFanService _fanService;
        private readonly IFavPlanetStore _favPlanetStore;
        public int FanId { get; set; }
        public FavPlanetService(IFavPlanetStore favPlanetStore, IFanService fanService)
        {
            _favPlanetStore = favPlanetStore;
            _fanService = fanService;
        }

        public void SetFanID(int fanId)
        {
            FanId = fanId;
        }



        public FanFavViewModel SelectFanFavPlanets(int fanId)
        {
            FanId = fanId;

            var dalFavPlanets = _favPlanetStore.SelectFanFavPlanets(FanId);

            var fanResults = _fanService.GetFanInfo(FanId);


            var favPlanets = new List<FavPlanet>();
            var fanFavViewModel = new FanFavViewModel();

            fanFavViewModel.FanName = fanResults.FanName;
            fanFavViewModel.FanId = fanResults.FanId;



            foreach (var dalFavPlanet in dalFavPlanets)
            {
                var favPlanet = new FavPlanet();
                favPlanet.FanId = dalFavPlanet.FanId;
                favPlanet.PlanetUrl = dalFavPlanet.PlanetUrl;

                favPlanets.Add(favPlanet);

            }

            fanFavViewModel.FavPlanets = favPlanets;

            return fanFavViewModel;
        }

        public FanFavViewModel SelectFanFavPlanets()
        {
            

            var dalFavPlanets = _favPlanetStore.SelectFanFavPlanets(FanId);

            var fanResults = _fanService.GetFanInfo(FanId);


            var favPlanets = new List<FavPlanet>();
            var fanFavViewModel = new FanFavViewModel();

            fanFavViewModel.FanName = fanResults.FanName;
            fanFavViewModel.FanId = fanResults.FanId;



            foreach (var dalFavPlanet in dalFavPlanets)
            {
                var favPlanet = new FavPlanet();
                favPlanet.FanId = dalFavPlanet.FanId;
                favPlanet.PlanetUrl = dalFavPlanet.PlanetUrl;

                favPlanets.Add(favPlanet);

            }

            fanFavViewModel.FavPlanets = favPlanets;

            return fanFavViewModel;
        }

        public FanFavViewModel DeleteFavorite(string url)
        {
            _favPlanetStore.DeleteFavorite(url, FanId);

            var dalFavPlanets = _favPlanetStore.SelectFanFavPlanets(FanId);
            var fanResults = _fanService.GetFanInfo(FanId);


            var favPlanets = new List<FavPlanet>();
            var fanFavViewModel = new FanFavViewModel();

            fanFavViewModel.FanName = fanResults.FanName;


            foreach (var dalFavPlanet in dalFavPlanets)
            {
                var favPlanet = new FavPlanet();
                favPlanet.FanId = dalFavPlanet.FanId;
                favPlanet.PlanetUrl = dalFavPlanet.PlanetUrl;

                favPlanets.Add(favPlanet);

            }

            fanFavViewModel.FanId = FanId;
            fanFavViewModel.FavPlanets = favPlanets;

            return fanFavViewModel;
        }
    }

       
    
}
