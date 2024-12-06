using Application.Interfaces;
using Azure.Core;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository(RealDatabase context) : Repository<User>(context), IUserRepository
    {
        private readonly RealDatabase _context = context;

        public async Task<User> LoginUser(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserName == username && 
                                                 user.Password == password) ??
                                                 throw new UnauthorizedAccessException("Invalid username or password");
        }

        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username);
        }
    }
}
