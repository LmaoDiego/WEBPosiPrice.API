using System;
using System.Threading.Tasks;
using PosiPrice.API.Domain.Persistence.Contexts;
using PosiPrice.API.Domain.Persistence.Repositories;

namespace PosiPrice.API.Persitence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
            {
            _context = context;
            }
        public async Task CompleteAsync()
        {//llamada asincrona
            await _context.SaveChangesAsync();
        }
    }
}