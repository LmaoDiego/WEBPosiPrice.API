using PosiPrice.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PosiPrice.API.Domain.Persistence.Repositories
{
    public interface IVoteRepository
    {
        Task<IEnumerable<Vote>> ListAsync();
        Task AddAsync(Vote vote);
        Task<Vote> FindById(int id);
        void Update(Vote vote);
        void Remove(Vote vote);
    }
}
