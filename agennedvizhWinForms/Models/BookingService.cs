using RealEstateAgency.Models;
using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace RealEstateAgency.Services
{
    public class BookingService
    {
        private readonly DatabaseService _dbService;

        public BookingService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public List<Booking> GetAllBookings()
        {
            var query = @"
                SELECT b.*, 
                       p.address as propertyaddress,
                       CONCAT(c.last_name, ' ', c.first_name, ' ', COALESCE(c.middle_name, '')) as clientname,
                       CONCAT(e.last_name, ' ', e.first_name, ' ', COALESCE(e.middle_name, '')) as employeename,
                       ps.name as propertystatus
                FROM bookings b
                JOIN properties p ON b.property_id = p.id
                JOIN clients c ON b.client_id = c.id
                JOIN employees e ON b.employee_id = e.id
                JOIN property_statuses ps ON p.status_id = ps.id
                ORDER BY b.booking_date DESC";

            var dataTable = _dbService.ExecuteQueryDisconnected(query);
            return MapBookings(dataTable);
        }

        public Booking? GetBookingById(int id)
        {
            var query = @"
                SELECT b.*, 
                       p.address as propertyaddress,
                       CONCAT(c.last_name, ' ', c.first_name, ' ', COALESCE(c.middle_name, '')) as clientname,
                       CONCAT(e.last_name, ' ', e.first_name, ' ', COALESCE(e.middle_name, '')) as employeename,
                       ps.name as propertystatus
                FROM bookings b
                JOIN properties p ON b.property_id = p.id
                JOIN clients c ON b.client_id = c.id
                JOIN employees e ON b.employee_id = e.id
                JOIN property_statuses ps ON p.status_id = ps.id
                WHERE b.id = @id";

            var parameters = new NpgsqlParameter[] { new("@id", id) };
            var dataTable = _dbService.ExecuteQueryConnected(query, parameters);

            return dataTable.Rows.Count > 0 ? MapBooking(dataTable.Rows[0]) : null;
        }

        public void AddBooking(Booking booking)
        {
            var query = @"
                INSERT INTO bookings (property_id, client_id, employee_id, booking_date, start_date, end_date, status, amount, notes)
                VALUES (@property_id, @client_id, @employee_id, @booking_date, @start_date, @end_date, @status, @amount, @notes)";

            var parameters = new NpgsqlParameter[]
            {
                new("@property_id", booking.PropertyId),
                new("@client_id", booking.ClientId),
                new("@employee_id", booking.EmployeeId),
                new("@booking_date", booking.BookingDate),
                new("@start_date", booking.StartDate),
                new("@end_date", booking.EndDate ?? (object)DBNull.Value),
                new("@status", booking.Status),
                new("@amount", booking.Amount ?? (object)DBNull.Value),
                new("@notes", booking.Notes)
            };

            _dbService.ExecuteNonQuery(query, parameters);
        }

        public void UpdateBooking(Booking booking)
        {
            var query = @"
                UPDATE bookings 
                SET property_id = @property_id,
                    client_id = @client_id,
                    employee_id = @employee_id,
                    booking_date = @booking_date,
                    start_date = @start_date,
                    end_date = @end_date,
                    status = @status,
                    amount = @amount,
                    notes = @notes
                WHERE id = @id";

            var parameters = new NpgsqlParameter[]
            {
                new("@id", booking.Id),
                new("@property_id", booking.PropertyId),
                new("@client_id", booking.ClientId),
                new("@employee_id", booking.EmployeeId),
                new("@booking_date", booking.BookingDate),
                new("@start_date", booking.StartDate),
                new("@end_date", booking.EndDate ?? (object)DBNull.Value),
                new("@status", booking.Status),
                new("@amount", booking.Amount ?? (object)DBNull.Value),
                new("@notes", booking.Notes)
            };

            _dbService.ExecuteNonQuery(query, parameters);
        }

        public void DeleteBooking(int id)
        {
            var query = "DELETE FROM bookings WHERE id = @id";
            var parameters = new NpgsqlParameter[] { new("@id", id) };
            _dbService.ExecuteNonQuery(query, parameters);
        }

        // Выборка с параметрами
        public List<Property> GetAvailableProperties(DateTime checkDate)
        {
            // Получаем все объекты недвижимости со статусом "Свободен" или "Забронирован"
            // и которые не забронированы на указанную дату
            var query = @"
                SELECT DISTINCT p.*, pt.name as propertytypename, ps.name as statusname
                FROM properties p
                JOIN property_types pt ON p.property_type_id = pt.id
                JOIN property_statuses ps ON p.status_id = ps.id
                WHERE ps.name IN ('Свободен', 'Забронирован')
                AND p.id NOT IN (
                    SELECT b.property_id 
                    FROM bookings b 
                    WHERE b.status = 'active'
                    AND @check_date BETWEEN b.start_date AND COALESCE(b.end_date, @check_date)
                )
                ORDER BY p.id";

            var parameters = new NpgsqlParameter[] { new("@check_date", checkDate) };
            var dataTable = _dbService.ExecuteQueryDisconnected(query, parameters);
            
            var properties = new List<Property>();
            foreach (DataRow row in dataTable.Rows)
            {
                properties.Add(new Property
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
                });
            }
            return properties;
        }

        private List<Booking> MapBookings(DataTable dataTable)
        {
            var bookings = new List<Booking>();
            foreach (DataRow row in dataTable.Rows)
            {
                bookings.Add(MapBooking(row));
            }
            return bookings;
        }

        private Booking MapBooking(DataRow row)
        {
            return new Booking
            {
                Id = Convert.ToInt32(row["id"]),
                PropertyId = Convert.ToInt32(row["property_id"]),
                ClientId = Convert.ToInt32(row["client_id"]),
                EmployeeId = Convert.ToInt32(row["employee_id"]),
                BookingDate = Convert.ToDateTime(row["booking_date"]),
                StartDate = Convert.ToDateTime(row["start_date"]),
                EndDate = row["end_date"] == DBNull.Value ? null : Convert.ToDateTime(row["end_date"]),
                Status = row["status"].ToString() ?? "active",
                Amount = row["amount"] == DBNull.Value ? null : Convert.ToDecimal(row["amount"]),
                Notes = row["notes"].ToString() ?? string.Empty,
                CreatedAt = Convert.ToDateTime(row["created_at"]),
                UpdatedAt = Convert.ToDateTime(row["updated_at"]),
                PropertyAddress = row["propertyaddress"].ToString() ?? string.Empty,
                ClientName = row["clientname"].ToString() ?? string.Empty,
                EmployeeName = row["employeename"].ToString() ?? string.Empty,
                PropertyStatus = row["propertystatus"].ToString() ?? string.Empty
            };
        }
    }
}