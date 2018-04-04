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
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }

                //if (string.IsNullOrEmpty(_connection.ConnectionString))
                //    _connection.ConnectionString = _connectionString;

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }
                
        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                //_connection = null;
            }            
        }
    }
}
