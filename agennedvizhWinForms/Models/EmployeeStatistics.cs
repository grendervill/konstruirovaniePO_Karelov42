namespace RealEstateAgency.Models
{
    public class EmployeeStatistics
    {
        public string EmployeeName { get; set; } = string.Empty;
        public int DealsCount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AverageAmount { get; set; }
    }
}