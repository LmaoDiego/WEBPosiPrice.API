using PosiPrice.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PosiPrice.API.Domain.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<IEnumerable<User>> ListByCategoryIdAsync(int categoryId);
    }
}