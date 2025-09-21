using System;

namespace RealEstateAgency.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PassportSeries { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public string RegistrationAddress { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        
        public string FullName => $"{LastName} {FirstName} {MiddleName}".Trim();
    }
}