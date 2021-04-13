using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _useRepo;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository useRepo, IMapper mapper)
        {
            _mapper = mapper;
            _useRepo = useRepo;
        }
        [Authorize]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _useRepo.GetMembersAsync();
            return Ok(users);
        }
        [Authorize]
        //api/users/2
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetUser(int id)
        {
            var user = await _useRepo.GetUserByIdAsync(id);
            return _mapper.Map<MemberDto>(user);;
        }

        [HttpGet("{username}", Name = "GetUser")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _useRepo.GetMemberAsync(username);
        }
    }
}