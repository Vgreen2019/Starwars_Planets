using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsApp.DAL
{
    public class FavPlanetStore: IFavPlanetStore
    {

        private readonly Database _config;

        public FavPlanetStore(StarWarsAppConfiguration config)
        {
            _config = config.Database;
        }

        public bool DeleteFavorite(string url, int fanId)
        {
            var sql = $@"DELETE FROM FavPlanet WHERE FanId = @FanId AND PlanetUrl = @PlanetUrl";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var results = connection.Execute(sql, new { FanId = fanId, PlanetUrl = url });

                return true;
            }
        }

        public IEnumerable<FavPlanetDALModel> SelectFanFavPlanets(int fanId)
        {
            var sql = @"SELECT * FROM FavPlanet WHERE FanId = @FanId";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var results = connection.Query<FavPlanetDALModel>(sql, new { FanId = fanId}) ?? new List<FavPlanetDALModel>();
                return results;

            }
        }
            
    }
}
