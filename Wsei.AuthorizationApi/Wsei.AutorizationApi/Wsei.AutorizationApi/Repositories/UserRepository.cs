using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using Wsei.AutorizationApi.Controllers;
using Wsei.AutorizationApi.Models;
using User = Wsei.AutorizationApi.Models.User;

namespace Wsei.AutorizationApi.Repositories
{
    public class UserRepository
    {
        private readonly AuthorizationDbContext _authorizationDbContext;

        public UserRepository(AuthorizationDbContext authorizationDbContext)
        {
            _authorizationDbContext = authorizationDbContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            IEnumerable<User> usersFromDb = _authorizationDbContext.Users.ToList();
            return usersFromDb;
        }
        public async Task<bool> AddAsync(User user)
        {
            await _authorizationDbContext.Users.AddAsync(user);
            await _authorizationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<User> GetLoggedUserAsync(UserDto requestedUser)
        {
            IEnumerable<User> usersFromDb = await _authorizationDbContext.Users.ToListAsync();
            foreach (var user in usersFromDb)
            {
                if (user.Username == requestedUser.Username)
                {
                    if (VerifyPasswordHash(requestedUser.Password, user.PasswordHash, user.PasswordSalt))
                    {
                        return user;
                    }
                    else
                    {
                        throw new Exception("Wrong password.");
                    }
                }
                else
                {
                    throw new Exception("User was not found.");
                }
            }
            throw new Exception("Something went wrong");
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return StructuralComparisons.StructuralEqualityComparer.Equals(computedHash, passwordHash);
            }
        }

    }
}
