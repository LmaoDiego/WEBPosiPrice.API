using PosiPrice.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PosiPrice.API.Domain.Persistence.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> ListAsync();
        Task AddAsync(Tag tag);
        Task<Tag> FindById(int id);
        void Update(Tag tag);
        void Remove(Tag tag);
    }
}
