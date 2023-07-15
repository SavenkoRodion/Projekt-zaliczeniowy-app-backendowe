using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Wsei.AutorizationApi.Models;
using Wsei.AutorizationApi.Repositories;

namespace Wsei.AutorizationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserRepository _userRepository;

        public AuthController(IConfiguration configuration, UserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new User()
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            return Ok(await _userRepository.AddAsync(user));
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            User loggedUser = await _userRepository.GetLoggedUserAsync(request);
            string token = await CreateTokenAsync(loggedUser);
            return Ok(token);
        }

        [HttpGet("grant-role-to-user")]
        public async Task<ActionResult<string>> GrantRoleToUserAsync(string userName, string role)
        {
            return await _userRepository.GrantRoleToUser(userName, role) is true ? Ok(true) : BadRequest(false);
        }

        [HttpDelete("revoke-admin-role-to-user")]
        public async Task<ActionResult<string>> RevokeUserRolesAsync(string userName)
        {
            return await _userRepository.RevokeUserRoles(userName) is true ? Ok(true) : BadRequest(false);
        }

        private async Task<string> CreateTokenAsync(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, await _userRepository.GetUserRoleAsync(user.Username))
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}