using System;
using System.Collections.Generic;

namespace API.DTO
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
        public string  Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } 
        public DateTime LastActive{get;set;} 
        public ICollection<PhotoDto> Photos{get; set;}
    }
}