using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Persistence.Contexts;
using PosiPrice.API.Domain.Persistence.Repositories;

namespace PosiPrice.API.Persitence.Repositories
{
    public class VoteRepository : BaseRepository, IVoteRepository
    {
        public VoteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Vote vote)
        {
            await _context.Votes.AddAsync(vote);
        }

        public async Task<Vote> FindById(int id)
        {
            return await _context.Votes.FindAsync(id);
        }

        public async Task<IEnumerable<Vote>> ListAsync()
        {
            return await _context.Votes.ToListAsync();
        }

        public void Remove(Vote vote)
        {
            _context.Votes.Remove(vote);
        }

        public void Update(Vote vote)
        {
            _context.Votes.Update(vote);
        }
    }
}
