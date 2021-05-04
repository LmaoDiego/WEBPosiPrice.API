using Microsoft.EntityFrameworkCore;
using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Persistence.Contexts;
using PosiPrice.API.Domain.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosiPrice.API.Persitence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.Include(p => p.Category).ToListAsync();
        }

        public async Task<IEnumerable<User>> ListByCategoryIdAsync(int categoryId)
        {
            return await _context.Users
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .ToListAsync();
        }
    }
}