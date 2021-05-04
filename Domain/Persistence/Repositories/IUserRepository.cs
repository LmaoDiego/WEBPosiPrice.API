using PosiPrice.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PosiPrice.API.Domain.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
     

        Task<User> FindById(int Id);

        Task AddAsync(User user);
        void Update(User user);
        void Remove(User user);
    }
}