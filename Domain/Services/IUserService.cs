using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PosiPrice.API.Domain.Services
{//fix
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<IEnumerable<User>> ListByCategoryIdAsync(int categoryId);
        Task<IEnumerable<User>> ListByVoteIdAsync(int voteId);
    }
}
