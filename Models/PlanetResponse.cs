using System;

namespace StarWarsApp.Models
{
    public partial class StarWarsPlanetResponse
    {
        public class PlanetResponse
        {
            public string Climate { get; set; } 
            public DateTime Created { get; set; }
            public string Diameter { get; set; }
            public DateTime Edited { get; set; }
            public string[] Films { get; set; }
            public string Gravity { get; set; }
            public string Name { get; set; }
            public string Orbital_Period { get; set; }
            public string Population { get; set; }
            public string[] Residents { get; set; }
            public string Rotation_Period { get; set; }
            public string Surface_Water { get; set; }
            public string Terrain { get; set; }
            public string Url { get; set; }
        }

    }
}
