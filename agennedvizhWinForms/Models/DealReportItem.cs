using System;

namespace RealEstateAgency.Models
{
    public class DealReportItem
    {
        public int DealId { get; set; }
        public DateTime DealDate { get; set; }
        public string PropertyAddress { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string DealType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}