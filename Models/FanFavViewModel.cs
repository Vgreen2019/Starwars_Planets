using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApp.Models
{
    public class FanFavViewModel
    {
        public string FanName { get; set; }
        public int FanId { get; set; }
        public IList<FavPlanet> FavPlanets { get; set; }

    }
}
