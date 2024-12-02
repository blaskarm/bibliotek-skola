
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuthorRepository(RealDatabase context) : Repository<Author>(context), IAuthorRepository
    {
        private readonly RealDatabase _context = context;

        public async Task<bool> AuthorExists(string name)
        {
            bool exists = await _context.Authors.AnyAsync(a => a.Name == name);
            return exists;
        }
    }
}
