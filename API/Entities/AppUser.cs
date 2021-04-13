using System;
using System.Collections.Generic;
using API.Entensions;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[]  PasswordSalt { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string  Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;    
        public DateTime LastActive{get;set;} = DateTime.Now;
        public ICollection<Photo> Photos{get; set;}
        // public int GetAge(){
        //     return DateOfBirth.CalculateAge();
        // }
    }
}