using PosiPrice.API.Domain.Persistence.Contexts;
using System;
namespace PosiPrice.API.Persitence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
