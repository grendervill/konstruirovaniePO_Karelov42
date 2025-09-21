using RealEstateAgency.Models;
using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace RealEstateAgency.Services
{
    public class ClientService
    {
        private readonly DatabaseService _dbService;

        public ClientService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public List<Client> GetAllClients()
        {
            var query = "SELECT * FROM clients ORDER BY id";
            var dataTable = _dbService.ExecuteQueryDisconnected(query);
            return MapClients(dataTable);
        }

        public Client? GetClientById(int id)
        {
            var query = "SELECT * FROM clients WHERE id = @id";
            var parameters = new NpgsqlParameter[] { new("@id", id) };
            var dataTable = _dbService.ExecuteQueryConnected(query, parameters);

            return dataTable.Rows.Count > 0 ? MapClient(dataTable.Rows[0]) : null;
        }

        public void AddClient(Client client)
        {
            var query = @"
                INSERT INTO clients (first_name, last_name, middle_name, phone, email, passport_series, passport_number, registration_address)
                VALUES (@first_name, @last_name, @middle_name, @phone, @email, @passport_series, @passport_number, @registration_address)";

            var parameters = new NpgsqlParameter[]
            {
                new("@first_name", client.FirstName),
                new("@last_name", client.LastName),
                new("@middle_name", string.IsNullOrEmpty(client.MiddleName) ? (object)DBNull.Value : client.MiddleName),
                new("@phone", string.IsNullOrEmpty(client.Phone) ? (object)DBNull.Value : client.Phone),
                new("@email", string.IsNullOrEmpty(client.Email) ? (object)DBNull.Value : client.Email),
                new("@passport_series", string.IsNullOrEmpty(client.PassportSeries) ? (object)DBNull.Value : client.PassportSeries),
                new("@passport_number", string.IsNullOrEmpty(client.PassportNumber) ? (object)DBNull.Value : client.PassportNumber),
                new("@registration_address", string.IsNullOrEmpty(client.RegistrationAddress) ? (object)DBNull.Value : client.RegistrationAddress)
            };

            _dbService.ExecuteNonQuery(query, parameters);
        }

        public void UpdateClient(Client client)
        {
            var query = @"
                UPDATE clients 
                SET first_name = @first_name,
                    last_name = @last_name,
                    middle_name = @middle_name,
                    phone = @phone,
                    email = @email,
                    passport_series = @passport_series,
                    passport_number = @passport_number,
                    registration_address = @registration_address
                WHERE id = @id";

            var parameters = new NpgsqlParameter[]
            {
                new("@id", client.Id),
                new("@first_name", client.FirstName),
                new("@last_name", client.LastName),
                new("@middle_name", string.IsNullOrEmpty(client.MiddleName) ? (object)DBNull.Value : client.MiddleName),
                new("@phone", string.IsNullOrEmpty(client.Phone) ? (object)DBNull.Value : client.Phone),
                new("@email", string.IsNullOrEmpty(client.Email) ? (object)DBNull.Value : client.Email),
                new("@passport_series", string.IsNullOrEmpty(client.PassportSeries) ? (object)DBNull.Value : client.PassportSeries),
                new("@passport_number", string.IsNullOrEmpty(client.PassportNumber) ? (object)DBNull.Value : client.PassportNumber),
                new("@registration_address", string.IsNullOrEmpty(client.RegistrationAddress) ? (object)DBNull.Value : client.RegistrationAddress)
            };

            _dbService.ExecuteNonQuery(query, parameters);
        }

        public void DeleteClient(int id)
        {
            var query = "DELETE FROM clients WHERE id = @id";
            var parameters = new NpgsqlParameter[] { new("@id", id) };
            _dbService.ExecuteNonQuery(query, parameters);
        }

        private List<Client> MapClients(DataTable dataTable)
        {
            var clients = new List<Client>();
            foreach (DataRow row in dataTable.Rows)
            {
                clients.Add(MapClient(row));
            }
            return clients;
        }

        private Client MapClient(DataRow row)
        {
            return new Client
            {
                Id = Convert.ToInt32(row["id"]),
                FirstName = row["first_name"].ToString() ?? string.Empty,
                LastName = row["last_name"].ToString() ?? string.Empty,
                MiddleName = row["middle_name"].ToString() ?? string.Empty,
                Phone = row["phone"].ToString() ?? string.Empty,
                Email = row["email"].ToString() ?? string.Empty,
                PassportSeries = row["passport_series"].ToString() ?? string.Empty,
                PassportNumber = row["passport_number"].ToString() ?? string.Empty,
                RegistrationAddress = row["registration_address"].ToString() ?? string.Empty,
                CreatedAt = Convert.ToDateTime(row["created_at"])
            };
        }
    }
}