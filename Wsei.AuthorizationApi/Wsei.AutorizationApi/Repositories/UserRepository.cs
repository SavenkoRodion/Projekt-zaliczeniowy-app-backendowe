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
            User? existingUser = await _authorizationDbContext.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (existingUser != null)
            {
                throw new Exception("User with the same username already exists.");
            }

            await _authorizationDbContext.Users.AddAsync(user);
            await _authorizationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<User> GetLoggedUserAsync(UserDto requestedUser)
        {
            IEnumerable<User> usersFromDb = await _authorizationDbContext.Users.ToListAsync();
            if (usersFromDb.Select(user => user.Username).Contains(requestedUser.Username))

            {
                foreach (var user in usersFromDb)
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
            }
            else
            {
                throw new Exception("User was not found.");
            }
            throw new Exception("Something went wrong");
        }

        public async Task<User?> GetUserByName(string userName)
        {
            return await _authorizationDbContext.Users.Where(dbUser => dbUser.Username == userName).FirstOrDefaultAsync();
        }

        public async Task<string?> GetUserRoleAsync(string userName)
        {
            return await _authorizationDbContext.Users
                .Where(dbUser => dbUser.Username == userName)
                .Select(dbUser => dbUser.Role.Name)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> GrantRoleToUser(string userName, string role)
        {
            await _authorizationDbContext.Users
                .Where(dbUser => dbUser.Username == userName)
                .ExecuteDeleteAsync();

            User user = await _authorizationDbContext.Users
                .Where(dbUser => dbUser.Username == userName).FirstAsync();

            user.Role = await _authorizationDbContext.Roles.Where(dbRole => dbRole.Name == role).FirstAsync();

            _authorizationDbContext.Users.Entry(user).State = EntityState.Modified;

            await _authorizationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RevokeUserRoles(string userName)
        {
            await _authorizationDbContext.Users
                .Where(dbUser => dbUser.Username == userName)
                .ExecuteDeleteAsync();

            User user = await _authorizationDbContext.Users
                .Where(dbUser => dbUser.Username == userName).FirstAsync();

            user.Role = null;

            _authorizationDbContext.Users.Entry(user).State = EntityState.Modified;

            await _authorizationDbContext.SaveChangesAsync();
            return true;
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
