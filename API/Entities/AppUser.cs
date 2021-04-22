using System;
using System.Collections.Generic;
using API.Entensions;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string  Company { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;    
        public DateTime LastActive{get;set;} = DateTime.Now;
        public ICollection<Photo> Photos{get; set;}
        // public int GetAge(){
        //     return DateOfBirth.CalculateAge();
        // }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}