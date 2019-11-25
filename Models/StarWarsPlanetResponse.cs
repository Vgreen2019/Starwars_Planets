using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApp.Models
{
    public partial class StarWarsPlanetResponse
    {
        //Handles Pagination?
        public int Count { get; set; }
        public string Next { get; set; }
        public object Previous { get; set; }
        public IEnumerable<PlanetResponse> Results { get; set; }

    }
}
