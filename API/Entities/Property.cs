using System;

namespace API.Entities
{
    public class REProperty
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string  Zip { get; set; }
        public DateTime AccquisitionDate { get; set; }
        public decimal AccquisitionValue{get; set;}
        public string FromUserName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}