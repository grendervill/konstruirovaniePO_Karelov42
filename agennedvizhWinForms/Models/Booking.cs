using System;

namespace RealEstateAgency.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = "active";
        public decimal? Amount { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        // Связанные данные для отображения
        public string PropertyAddress { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string PropertyStatus { get; set; } = string.Empty;
    }
}