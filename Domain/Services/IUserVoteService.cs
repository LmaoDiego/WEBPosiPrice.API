using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PosiPrice.API.Domain.Services
{
    public interface IUserVoteService
    {
        Task<IEnumerable<UserVote>> ListAsync();
        Task<IEnumerable<UserVote>> ListByUserIdAsync(int userId);
        Task<IEnumerable<UserVote>> ListByVoteIdAsync(int voteId);
        Task<UserVoteResponse> AssignUserVoteAsync(int userId, int voteId);
        Task<UserVoteResponse> UnassignUserVoteAsync(int userId, int voteId);
    }
}