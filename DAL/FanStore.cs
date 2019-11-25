using Dapper;
using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace StarWarsApp.DAL
{
    public class FanStore:IFanStore
    {
        private readonly Database _config;

        public FanStore(StarWarsAppConfiguration config)
        {
            _config = config.Database;
        }

        public IEnumerable<FanDALModel> SelectAllFans()
        {
            var sql = @"SELECT * FROM Fan ORDER BY FanName ASC";

            using (var connection = new SqlConnection(_config.ConnectionString))    
            {
                var results = connection.Query<FanDALModel>(sql) ?? new List<FanDALModel>();
                return results;

            }
        }

        public bool InsertNewFan(FanDALModel dalModel)
        {
            var sql = $@"INSERT INTO Fan (FanName) 
                            VALUES (@{nameof(dalModel.FanName)})";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var results = connection.Execute(sql, dalModel);

                return true;
            }            
        }

        public bool InsertFavPlanet(int fanId, string favPlanet)
        {
            var sql = @"INSERT INTO FavPlanet (FanId, PlanetUrl) 
                            VALUES (@FanId, @PlanetUrl)";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var results = connection.Execute(sql, new { FanId = fanId, PlanetUrl = favPlanet });

                return true;
            }


        }

        public FanDALModel GetFanInfo(int fanId)
        {
            var sql = @"SELECT * FROM Fan WHERE FanId = @FanId";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var results = connection.QueryFirstOrDefault<FanDALModel>(sql, new { FanId = fanId });
                return results;

            }
        }
    }
}
