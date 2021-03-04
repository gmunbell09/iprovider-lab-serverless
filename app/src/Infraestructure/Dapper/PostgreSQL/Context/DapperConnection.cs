using Core.Common;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Infraestructure.Dapper.PostgreSQL.Context
{
    public class DapperConnection : IDapperConnection
    {
        private readonly Settings _settings;
        private readonly string _connectionString;
        private IDbConnection _connection;

        public DapperConnection(Settings settings)
        {
            _settings = settings;
            _connectionString = settings.ConnectionStrings.DefaultConnection;
        }

        public IDbConnection Connection => _connection ?? (_connection = new NpgsqlConnection(_connectionString));

        public IDbTransaction Transaction { get ; set; }

        public IDbConnection CreateConnection()
        {
            _connection =  new NpgsqlConnection(_connectionString);
            return Connection;
        }

        public void Dispose()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
        }
    }
}
