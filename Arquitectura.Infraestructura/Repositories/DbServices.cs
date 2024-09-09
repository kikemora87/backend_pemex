using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arquitectura.Domain.Interfaces.Repositories;
using Arquitectura.Domain.POCOs;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Arquitectura.Infraestructura.Repositories
{
    public class DbServices : IDbServices
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _db;

        public DbServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _db = new NpgsqlConnection(configuration.GetConnectionString("Connection"));
        }

        public async Task<T> GetAsync<T>(string command, object parms)
        {
            T result;

            result = (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();

            return result;

        }

        public async Task<List<T>> GetAll<T>(string command, object parms)
        {

            List<T> result = new List<T>();

            result = (await _db.QueryAsync<T>(command, parms)).ToList();

            return result;
        }

        public async Task<int> EditData(string command, object parms)
        {
            int result;

            result = await _db.ExecuteAsync(command, parms);

            return result;
        }
    }
}
