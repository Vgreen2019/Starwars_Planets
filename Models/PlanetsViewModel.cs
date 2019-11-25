using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApp.Models
{
    public class PlanetsViewModel
    {
        public int FanId { get; set; }
        public IList<Planet> Planets { get; set; }

    }
}
