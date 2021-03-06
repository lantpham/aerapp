using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager){
            if(await userManager.Users.AnyAsync()) return;
            var userData =  await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            foreach(var user in users){
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }

        }
        //public static async Task SeedProperty(DataContext context){
            // if(await context.Users.AnyAsync()) return;
            // var userData =  await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            // var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            // foreach(var user in users){
            //     //using var hmac= new HMACSHA512();
            //     user.UserName = user.UserName.ToLower();
            //     // user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
            //     // user.PasswordHash = hmac.Key;
            //     context.Users.Add(user);
            // }

        //}
    }
}