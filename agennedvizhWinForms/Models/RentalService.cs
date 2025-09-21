using RealEstateAgency.Models;
using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace RealEstateAgency.Services
{
    public class RentalService
    {
        private readonly DatabaseService _dbService;

        public RentalService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public List<RentalType> GetAllRentalTypes()
        {
            var query = "SELECT * FROM rental_types ORDER BY id";
            var dataTable = _dbService.ExecuteQueryDisconnected(query);
            
            var rentalTypes = new List<RentalType>();
            foreach (DataRow row in dataTable.Rows)
            {
                rentalTypes.Add(new RentalType
                {
                    Id = Convert.ToInt32(row["id"]),
                    Name = row["name"].ToString() ?? string.Empty,
                    Description = row["description"].ToString() ?? string.Empty
                });
            }
            return rentalTypes;
        }

        public void CreateRentalDeal(Deal deal, DateTime startDate, DateTime? endDate)
        {
            var query = @"
                INSERT INTO deals (deal_type_id, property_id, client_id, employee_id, deal_date, amount, commission, contract_number, notes, start_date, end_date)
                VALUES (@deal_type_id, @property_id, @client_id, @employee_id, @deal_date, @amount, @commission, @contract_number, @notes, @start_date, @end_date)";

            var parameters = new NpgsqlParameter[]
            {
                new("@deal_type_id", deal.DealTypeId),
                new("@property_id", deal.PropertyId),
                new("@client_id", deal.ClientId),
                new("@employee_id", deal.EmployeeId),
                new("@deal_date", deal.DealDate),
                new("@amount", deal.Amount),
                new("@commission", deal.Commission ?? (object)DBNull.Value),
                new("@contract_number", deal.ContractNumber),
                new("@notes", deal.Notes),
                new("@start_date", startDate),
                new("@end_date", endDate ?? (object)DBNull.Value)
            };

            _dbService.ExecuteNonQuery(query, parameters);
        }
    }
}