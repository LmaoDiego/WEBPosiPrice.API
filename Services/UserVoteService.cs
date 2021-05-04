using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Persistence.Repositories;
using PosiPrice.API.Domain.Services;
using PosiPrice.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PosiPrice.API.Services
{
    public class UserVoteService : IUserVoteService
    {
        private readonly IUserVoteRepository _userVoteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserVoteService(IUserVoteRepository userVoteRepository, IUnitOfWork unitOfWork)
        {
            _userVoteRepository = userVoteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserVote>> ListAsync()
        {
            return await _userVoteRepository.ListAsync();
        }

        public async Task<IEnumerable<UserVote>> ListByUserIdAsync(int userId)
        {
            return await _userVoteRepository.ListByUserIdAsync(userId);
        }

        public async Task<IEnumerable<UserVote>> ListByVoteIdAsync(int voteId)
        {
            return await _userVoteRepository.ListByVoteIdAsync(voteId);
        }

        public async Task<UserVoteResponse> AssignUserVoteAsync(int userId, int voteId)
        {
            try
            {
                await _userVoteRepository.AssignUserVote(userId, voteId);
                await _unitOfWork.CompleteAsync();
                UserVote userVote = await _userVoteRepository.FindByUserIdAndVoteId(userId, voteId);
                return new UserVoteResponse(userVote);

            }
            catch (Exception ex)
            {
                return new UserVoteResponse($"An error ocurred while assigning Vote to User: {ex.Message}");
            }
        }

        public async Task<UserVoteResponse> UnassignUserVoteAsync(int userId, int voteId)
        {
            try
            {
                UserVote userVote = await _userVoteRepository.FindByUserIdAndVoteId(userId, voteId);

                _userVoteRepository.Remove(userVote);
                await _unitOfWork.CompleteAsync();

                return new UserVoteResponse(userVote);

            }
            catch (Exception ex)
            {
                return new UserVoteResponse($"An error ocurred while unassigning Vote from User: {ex.Message}");
            }

        }

        
    }
}