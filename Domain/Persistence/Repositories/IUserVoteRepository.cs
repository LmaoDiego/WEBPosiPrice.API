using PosiPrice.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PosiPrice.API.Domain.Persistence.Repositories
{
    public interface IUserVoteRepository
    {
        Task<IEnumerable<UserVote>> ListAsync();
        Task<IEnumerable<UserVote>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserVote>> ListByVoteIdAsync(int voteId);
        Task<UserVote> FindByUserIdAndVoteId(int userId, int voteId);
        Task AddAsync(UserVote userVote);
        void Remove(UserVote userVote);
        Task AssignUserVote(int userId, int voteId);
        Task UnassignUserVote(int userId, int voteId);

    }
}