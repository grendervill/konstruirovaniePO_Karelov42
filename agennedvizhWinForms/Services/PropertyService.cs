using RealEstateAgency.Models;
using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace RealEstateAgency.Services
{
    public class PropertyService
    {
        private readonly DatabaseService _dbService;

        public PropertyService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public List<Property> GetAllProperties()
        {
            var query = @"
                SELECT p.*, pt.name as propertytypename, ps.name as statusname
                FROM properties p
                JOIN property_types pt ON p.property_type_id = pt.id
                JOIN property_statuses ps ON p.status_id = ps.id
                ORDER BY p.id";

            var dataTable = _dbService.ExecuteQueryDisconnected(query);
            return MapProperties(dataTable);
        }

        public Property? GetPropertyById(int id)
        {
            var query = @"
                SELECT p.*, pt.name as propertytypename, ps.name as statusname
                FROM properties p
                JOIN property_types pt ON p.property_type_id = pt.id
                JOIN property_statuses ps ON p.status_id = ps.id
                WHERE p.id = @id";

            var parameters = new NpgsqlParameter[] { new("@id", id) };
            var dataTable = _dbService.ExecuteQueryConnected(query, parameters);

            return dataTable.Rows.Count > 0 ? MapProperty(dataTable.Rows[0]) : null;
        }

        public void AddProperty(Property property)
        {
            var query = @"
                INSERT INTO properties (property_type_id, status_id, address, city, area, rooms, floor, total_floors, price, description)
                VALUES (@property_type_id, @status_id, @address, @city, @area, @rooms, @floor, @total_floors, @price, @description)";

            var parameters = new NpgsqlParameter[]
            {
                new("@property_type_id", property.PropertyTypeId),
                new("@status_id", property.StatusId),
                new("@address", property.Address),
                new("@city", property.City),
                new("@area", property.Area ?? (object)DBNull.Value),
                new("@rooms", property.Rooms ?? (object)DBNull.Value),
                new("@floor", property.Floor ?? (object)DBNull.Value),
                new("@total_floors", property.TotalFloors ?? (object)DBNull.Value),
                new("@price", property.Price ?? (object)DBNull.Value),
                new("@description", property.Description)
            };

            _dbService.ExecuteNonQuery(query, parameters);
        }

        public void UpdateProperty(Property property)
        {
            var query = @"
                UPDATE properties 
                SET property_type_id = @property_type_id, 
                    status_id = @status_id,
                    address = @address,
                    city = @city,
                    area = @area,
                    rooms = @rooms,
                    floor = @floor,
                    total_floors = @total_floors,
                    price = @price,
                    description = @description
                WHERE id = @id";

            var parameters = new NpgsqlParameter[]
            {
                new("@id", property.Id),
                new("@property_type_id", property.PropertyTypeId),
                new("@status_id", property.StatusId),
                new("@address", property.Address),
                new("@city", property.City),
                new("@area", property.Area ?? (object)DBNull.Value),
                new("@rooms", property.Rooms ?? (object)DBNull.Value),
                new("@floor", property.Floor ?? (object)DBNull.Value),
                new("@total_floors", property.TotalFloors ?? (object)DBNull.Value),
                new("@price", property.Price ?? (object)DBNull.Value),
                new("@description", property.Description)
            };

            _dbService.ExecuteNonQuery(query, parameters);
        }

        public void DeleteProperty(int id)
        {
            var query = "DELETE FROM properties WHERE id = @id";
            var parameters = new NpgsqlParameter[] { new("@id", id) };
            _dbService.ExecuteNonQuery(query, parameters);
        }

        private List<Property> MapProperties(DataTable dataTable)
        {
            var properties = new List<Property>();
            foreach (DataRow row in dataTable.Rows)
            {
                properties.Add(MapProperty(row));
            }
            return properties;
        }

        private Property MapProperty(DataRow row)
        {
            return new Property
            {
                Id = Convert.ToInt32(row["id"]),
                PropertyTypeId = Convert.ToInt32(row["property_type_id"]),
                StatusId = Convert.ToInt32(row["status_id"]),
                Address = row["address"].ToString() ?? string.Empty,
                City = row["city"].ToString() ?? string.Empty,
                Area = row["area"] == DBNull.Value ? null : Convert.ToDecimal(row["area"]),
                Rooms = row["rooms"] == DBNull.Value ? null : Convert.ToInt32(row["rooms"]),
                Floor = row["floor"] == DBNull.Value ? null : Convert.ToInt32(row["floor"]),
                TotalFloors = row["total_floors"] == DBNull.Value ? null : Convert.ToInt32(row["total_floors"]),
                Price = row["price"] == DBNull.Value ? null : Convert.ToDecimal(row["price"]),
                Description = row["description"].ToString() ?? string.Empty,
                CreatedAt = Convert.ToDateTime(row["created_at"]),
                UpdatedAt = Convert.ToDateTime(row["updated_at"]),
                PropertyTypeName = row["propertytypename"].ToString() ?? string.Empty,
                StatusName = row["statusname"].ToString() ?? string.Empty
            };
        }
    }
}