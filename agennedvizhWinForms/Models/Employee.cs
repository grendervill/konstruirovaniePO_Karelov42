using System;

namespace RealEstateAgency.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? HireDate { get; set; }
        public decimal? Salary { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public string FullName => $"{LastName} {FirstName} {MiddleName}".Trim();
    }
}