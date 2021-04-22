using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController( UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
         ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
            //using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower()
                // ,
                // PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                // PasswordSalt = hmac.Key
            };
            //_context.Users.Add(user);
            //await _context.SaveChangesAsync();
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if(!result.Succeeded) return  BadRequest(result.Errors);
            //add user Photo here
            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)

            };
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
            .Include(photox=>photox.Photos)
            .SingleOrDefaultAsync(y => y.UserName == loginDto.Username.ToLower());
            if (user == null) return Unauthorized("invalid user");
            //using var hmac = new HMACSHA512(user.PasswordSalt);
            //var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            // for (int i = 0; i < computedHash.Length; i++)
            // {
            //     if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("wrong password");
            // }
            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
                PhotoUrl = user.Photos.FirstOrDefault(xx=>xx.IsMain)?.Url
                
            };
        }
        private async Task<bool> UserExists(string userName)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == userName.ToLower());
        }

    }
}