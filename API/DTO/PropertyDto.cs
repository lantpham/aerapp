using System;

namespace API.DTO
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string  Zip { get; set; }
        public DateTime AccquisitionDate { get; set; }
        public decimal AccquisitionValue{get; set;}
    }
}