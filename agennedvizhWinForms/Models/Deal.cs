using System;

namespace RealEstateAgency.Models
{
    public class Deal
    {
        public int Id { get; set; }
        public int DealTypeId { get; set; }
        public int PropertyId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DealDate { get; set; }
        public decimal Amount { get; set; }
        public decimal? Commission { get; set; }
        public string ContractNumber { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string DealTypeName { get; set; } = string.Empty;
        public string PropertyAddress { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
    }
}