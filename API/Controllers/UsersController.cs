using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        //api/users/2
        [HttpGet("{id}")]
        public ActionResult <AppUser> GetUser(int id){
            var user  = _context.Users.Find(id);
            return user;
        }
    }
}