using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Services.Communications;
namespace PosiPrice.API.Domain.Services
{
    public interface IVoteService
    {
        Task<IEnumerable<Vote>> ListAsync();
        Task<IEnumerable<Vote>> ListByUserIdAsync(int userId);
        Task<VoteResponse> GetByIdAsync(int id);
        Task<VoteResponse> SaveAsync(Vote vote);
        Task<VoteResponse> UpdateAsync(int id, Vote vote);
        Task<VoteResponse> DeleteAsync(int id);
    }
}