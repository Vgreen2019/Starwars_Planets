using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApp.Models
{
    public class FavoritePlanets
    {
        public int FanId { get; set; }
        public string PlanetUrl { get; set; }
        public string Message { get; set; }
    }
}
