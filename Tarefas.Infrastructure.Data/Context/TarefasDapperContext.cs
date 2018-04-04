using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Tarefas.Infrastructure.Data.Context
{
    public class TarefasDapperContext
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public TarefasDapperContext()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")    //como se fosse um app.config
                .Build();

            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public IDbConnection DapperConnection
        {
            get
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();

                return _connection;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
