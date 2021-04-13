using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _useRepo;
        public UsersController(IUserRepository useRepo)
        {
            _useRepo = useRepo;
        }
        [Authorize]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return Ok(await _useRepo.GetUsersAsync());
        }
        [Authorize]
        //api/users/2
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return Ok(await _useRepo.GetUserByIdAsync(id));
        }
    }
}