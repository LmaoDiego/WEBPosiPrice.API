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
    public class UserVoteRepository : BaseRepository, IUserVoteRepository
    {
        public UserVoteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(UserVote userVote)
        {
            await _context.UserVotes.AddAsync(userVote);
        }

        public async Task AssignUserVote(int userId, int voteId)
        {
            UserVote userVote = await FindByUserIdAndVoteId(userId, voteId);
            if (userVote == null)
            {
                userVote = new UserVote { UserId = userId, VoteId = voteId };
                await AddAsync(userVote);
            }
        }

        public async Task<UserVote> FindByUserIdAndVoteId(int userId, int voteId)
        {
            return await _context.UserVotes.FindAsync(userId, voteId);
        }

        public async Task<IEnumerable<UserVote>> ListAsync()
        {
            return await _context.UserVotes
                .Include(pt => pt.User)
                .Include(pt => pt.Vote)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserVote>> ListByUserIdAsync(int userId)
        {
            return await _context.UserVotes
                .Where(pt => pt.UserId == userId)
                .Include(pt => pt.User)
                .Include(pt => pt.Vote)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserVote>> ListByVoteIdAsync(int voteId)
        {
            return await _context.UserVotes
                .Where(pt => pt.VoteId == voteId)
                .Include(pt => pt.User)
                .Include(pt => pt.Vote)
                .ToListAsync();

        }

        public void Remove(UserVote userVote)
        {
            _context.UserVotes.Remove(userVote);
        }

        public async Task UnassignUserVote(int userId, int voteId)
        {
            UserVote userVote = await FindByUserIdAndVoteId(userId, voteId);
            if (userVote != null)
                Remove(userVote);
        }
    }
}