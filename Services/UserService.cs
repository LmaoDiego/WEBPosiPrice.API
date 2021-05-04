using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Persistence.Repositories;
using PosiPrice.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosiPrice.API.Services
{
    public class UserService : IUserService
    {
     
        private readonly IUserRepository _userRepository;
        private readonly IUserVoteRepository _userVoteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUserVoteRepository userVoteRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userVoteRepository = userVoteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<IEnumerable<User>> ListByCategoryIdAsync(int categoryId)
        {
            return await _userRepository.ListByCategoryIdAsync(categoryId);
        }

        public async Task<IEnumerable<User>> ListByVoteIdAsync(int voteId)
        {
            var userVotes = await _userVoteRepository.ListByVoteIdAsync(voteId);
            var products = userVotes.Select(pt => pt.User).ToList();
            return products;
        }
    }
}
