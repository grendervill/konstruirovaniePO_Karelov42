using System;

namespace RealEstateAgency.Models
{
    public class Property
    {
        public int Id { get; set; }
        public int PropertyTypeId { get; set; }
        public int StatusId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public decimal? Area { get; set; }
        public int? Rooms { get; set; }
        public int? Floor { get; set; }
        public int? TotalFloors { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string PropertyTypeName { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
    }
}