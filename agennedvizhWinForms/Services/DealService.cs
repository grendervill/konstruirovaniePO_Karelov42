using RealEstateAgency.Models;
using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace RealEstateAgency.Services
{
    public class DealService
    {
        private readonly DatabaseService _dbService;

        public DealService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public List<Deal> GetAllDeals()
        {
            var query = @"
                SELECT d.*, dt.name as dealtypename, p.address as propertyaddress,
                       CONCAT(c.last_name, ' ', c.first_name, ' ', COALESCE(c.middle_name, '')) as clientname,
                       CONCAT(e.last_name, ' ', e.first_name, ' ', COALESCE(e.middle_name, '')) as employeename
                FROM deals d
                JOIN deal_types dt ON d.deal_type_id = dt.id
                JOIN properties p ON d.property_id = p.id
                JOIN clients c ON d.client_id = c.id
                JOIN employees e ON d.employee_id = e.id
                ORDER BY d.deal_date DESC";

            var dataTable = _dbService.ExecuteQueryDisconnected(query);
            return MapDeals(dataTable);
        }
// Выборка с использованием хранимой процедуры
        public List<DealReportItem> GetDealsByPeriod(DateTime startDate, DateTime endDate)
        {
            var query = "SELECT * FROM get_deals_by_period(@start_date, @end_date)"; // Хранимая процедура
    
            var parameters = new NpgsqlParameter[]
            {
                new("@start_date", startDate),
                new("@end_date", endDate)
            };

            // Подключенный способ с хранимой процедурой
            var dataTable = _dbService.ExecuteQueryConnected(query, parameters); // Использование хранимой процедуры
            return MapDealReportItems(dataTable);
        }

        public List<EmployeeStatistics> GetEmployeeStatistics(DateTime startDate, DateTime endDate)
        {
            var query = "SELECT * FROM get_employee_statistics(@start_date, @end_date)";
    
            var parameters = new NpgsqlParameter[]
            {
                new("@start_date", startDate),
                new("@end_date", endDate)
            };

            // Отключенный способ с хранимой процедурой
            var dataTable = _dbService.ExecuteQueryDisconnected(query, parameters);
            return MapEmployeeStatistics(dataTable);
        }

        private List<Deal> MapDeals(DataTable dataTable)
        {
            var deals = new List<Deal>();
            foreach (DataRow row in dataTable.Rows)
            {
                deals.Add(MapDeal(row));
            }
            return deals;
        }

        private Deal MapDeal(DataRow row)
        {
            return new Deal
            {
                Id = Convert.ToInt32(row["id"]),
                DealTypeId = Convert.ToInt32(row["deal_type_id"]),
                PropertyId = Convert.ToInt32(row["property_id"]),
                ClientId = Convert.ToInt32(row["client_id"]),
                EmployeeId = Convert.ToInt32(row["employee_id"]),
                DealDate = Convert.ToDateTime(row["deal_date"]),
                Amount = Convert.ToDecimal(row["amount"]),
                Commission = row["commission"] == DBNull.Value ? null : Convert.ToDecimal(row["commission"]),
                ContractNumber = row["contract_number"].ToString() ?? string.Empty,
                Notes = row["notes"].ToString() ?? string.Empty,
                CreatedAt = Convert.ToDateTime(row["created_at"]),
                DealTypeName = row["dealtypename"].ToString() ?? string.Empty,
                PropertyAddress = row["propertyaddress"].ToString() ?? string.Empty,
                ClientName = row["clientname"].ToString() ?? string.Empty,
                EmployeeName = row["employeename"].ToString() ?? string.Empty
            };
        }

        private List<DealReportItem> MapDealReportItems(DataTable dataTable)
        {
            var items = new List<DealReportItem>();
            foreach (DataRow row in dataTable.Rows)
            {
                items.Add(new DealReportItem
                {
                    DealId = Convert.ToInt32(row["deal_id"]),
                    DealDate = Convert.ToDateTime(row["deal_date"]),
                    PropertyAddress = row["property_address"].ToString() ?? string.Empty,
                    ClientName = row["client_name"].ToString() ?? string.Empty,
                    EmployeeName = row["employee_name"].ToString() ?? string.Empty,
                    DealType = row["deal_type"].ToString() ?? string.Empty,
                    Amount = Convert.ToDecimal(row["amount"])
                });
            }
            return items;
        }

        private List<EmployeeStatistics> MapEmployeeStatistics(DataTable dataTable)
        {
            var stats = new List<EmployeeStatistics>();
            foreach (DataRow row in dataTable.Rows)
            {
                stats.Add(new EmployeeStatistics
                {
                    EmployeeName = row["employee_name"].ToString() ?? string.Empty,
                    DealsCount = Convert.ToInt32(row["deals_count"]),
                    TotalAmount = Convert.ToDecimal(row["total_amount"]),
                    AverageAmount = Convert.ToDecimal(row["average_amount"])
                });
            }
            return stats;
        }
    }
}