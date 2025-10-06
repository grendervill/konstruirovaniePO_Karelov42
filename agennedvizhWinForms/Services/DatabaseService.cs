using Npgsql;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RealEstateAgency.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString = string.Empty;

        public DatabaseService()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        // Подключенный способ (Connected) - данные доступны только пока открыто соединение
        // Подключенный способ (Connected)
        public DataTable ExecuteQueryConnected(string query, params NpgsqlParameter[]? parameters)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            
            using var command = new NpgsqlCommand(query, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            
            using var reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);
            return dataTable;
        }

        // Отключенный способ (Disconnected) - данные доступны после закрытия соединения
        // Отключенный способ (Disconnected)
        public DataTable ExecuteQueryDisconnected(string query, params NpgsqlParameter[]? parameters)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            using var adapter = new NpgsqlDataAdapter(query, connection);
            
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    adapter.SelectCommand.Parameters.Add(param);
                }
            }
            
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public int ExecuteNonQuery(string query, params NpgsqlParameter[]? parameters)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            
            using var command = new NpgsqlCommand(query, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            
            return command.ExecuteNonQuery();
        }

        public object? ExecuteScalar(string query, params NpgsqlParameter[]? parameters)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            
            using var command = new NpgsqlCommand(query, connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            
            return command.ExecuteScalar();
        }
    }
}