using Microsoft.AspNetCore.Mvc;
using StarWarsApp.Models;
using StarWarsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApp.Controllers
{
    public class StarwarsController: Controller
    {
        private readonly IFanService _fanService;
        private readonly IStarWarsFacade _starWarsFacade;
        private readonly IFavPlanetService _favPlanetService;

        public StarwarsController(IFanService fanService, IStarWarsFacade starWarsFacade, IFavPlanetService favPlanetService)
        {
            _fanService = fanService;
            _starWarsFacade = starWarsFacade;
            _favPlanetService = favPlanetService;
        }

        public IActionResult ViewAllFans()
        {
            var result = _fanService.GetAllFans();
            return View(result);
        }

        public IActionResult CreateFan()
        {
            return View();
        }

        public IActionResult CreateFanResults(AddFanViewModel model)
        {
            var fansViewModel = _fanService.AddNewFan(model);
            return View("ViewAllFans", fansViewModel);
        }

        public IActionResult AddFanResults(AddFanViewModel model)
        {
            var fansViewModel = _fanService.AddNewFan(model);
            return View("ViewAllFans", fansViewModel);
        }

        public async Task<IActionResult> ViewAllPlanets()
        {
            var result = await _starWarsFacade.GetAllPlanets();
            return View(result);
        }

        public async Task<IActionResult> ViewPlanet(string url)
        {
            var result = await _starWarsFacade.GetAPlanet(url);
            return View(result);
        }

        public async Task<IActionResult> ChooseFavoritePlanet(int fanId)    
        {
             _fanService.SetFanID(fanId);
            _favPlanetService.SetFanID(fanId);

            var result = await _starWarsFacade.GetAllPlanets();
            return View(result);
        }

       
        public async Task<IActionResult> AddToFavorites(string url)
        {
            _fanService.SetFavPlanetUrl(url);
            _fanService.AddFavoritePlanets();  

            var result = await _starWarsFacade.GetAPlanet(url);
            return View(result);
        }

        public IActionResult ViewAllFanFave(int fanId)
        {
            _fanService.SetFanID(fanId);
            _favPlanetService.SetFanID(fanId);

            var result = _favPlanetService.SelectFanFavPlanets(fanId);
            return View(result);
        }

        public IActionResult DeleteFavorite(string planetUrl)
        {
            var result = _favPlanetService.DeleteFavorite(planetUrl);
            return View(result);
             
        }

        public async Task<IActionResult> AddAnotherFavPlanet()
        {
            //_fanService.SetFanID(model.FanId);
            //_favPlanetService.SetFanID(model.FanId);

            var result = await _starWarsFacade.GetAllPlanets();
            return View(result);
        }

        public IActionResult AddAnotherFav(string planetUrl)
        {
            _fanService.SetFavPlanetUrl(planetUrl);
            _fanService.AddFavoritePlanets();

            var result = _favPlanetService.SelectFanFavPlanets();
            return View(result);

        }
    }

}
