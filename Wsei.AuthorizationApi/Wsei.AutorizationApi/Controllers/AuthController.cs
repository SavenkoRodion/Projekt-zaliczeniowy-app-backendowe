using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        [AllowAnonymous]
        public async Task<ActionResult<bool>> RegisterAsync(UserDto request)
        {
            PasswordUtil.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new User()
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsAdmin = false
            };
            return Ok(await _userRepository.AddAsync(user));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> LoginAsync(UserDto request)
        {
            User loggedUser = await _userRepository.GetLoggedUserAsync(request);
            string token = await CreateTokenAsync(loggedUser);
            return Ok(token);
        }

        [HttpGet("grant-admin-role-to-user")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> GrantAdminRoleToUserAsync(string userName)
        {
            return Ok(await _userRepository.GrantAdminRoleToUser(userName));
        }

        [HttpDelete("revoke-admin-role-to-user")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> RevokeUserRolesAsync(string userName)
        {
            return await _userRepository.RevokeUserRoles(userName) is true ? Ok(true) : BadRequest(false);
        }

        private async Task<string> CreateTokenAsync(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
            };

            if (await _userRepository.IsAdmin(user.Username))
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            claims.Add(new Claim(ClaimTypes.Role, "User"));

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

    }
}