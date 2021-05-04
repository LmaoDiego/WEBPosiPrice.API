using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Persistence.Repositories;
using PosiPrice.API.Domain.Services;
using PosiPrice.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosiPrice.API.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;
        private readonly IUserVoteRepository _userVoteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VoteService(IVoteRepository voteRepository, IUnitOfWork unitOfWork, IUserVoteRepository userVoteRepository)
        {
            _voteRepository = voteRepository;
            _unitOfWork = unitOfWork;
            _userVoteRepository = userVoteRepository;
        }

        public async Task<VoteResponse> DeleteAsync(int id)
        {
            var existingVote = await _voteRepository.FindById(id);

            if (existingVote == null)
                return new VoteResponse("Vote not found");

            try
            {
                _voteRepository.Remove(existingVote);
                await _unitOfWork.CompleteAsync();

                return new VoteResponse(existingVote);
            }
            catch (Exception ex)
            {
                return new VoteResponse($"An error ocurred while deleting vote: {ex.Message}");
            }
        }

        public async Task<VoteResponse> GetByIdAsync(int id)
        {
            var existingVote = await _voteRepository.FindById(id);

            if (existingVote == null)
                return new VoteResponse("Vote not found");
            return new VoteResponse(existingVote);
        }

        public async Task<IEnumerable<Vote>> ListAsync()
        {
            return await _voteRepository.ListAsync();

        }

        public async Task<IEnumerable<Vote>> ListByUserIdAsync(int userId)
        {
            var userVotes = await _userVoteRepository.ListByUserIdAsync(userId);
            var votes = userVotes.Select(pt => pt.Vote).ToList();
            return votes;
        }

        public async Task<VoteResponse> SaveAsync(Vote vote)
        {
            try
            {
                await _voteRepository.AddAsync(vote);
                await _unitOfWork.CompleteAsync();

                return new VoteResponse(vote);
            }
            catch (Exception ex)
            {
                return new VoteResponse($"An error ocurred while saving the vote: {ex.Message}");
            }
        }

        public async Task<VoteResponse> UpdateAsync(int id, Vote vote)
        {
            var existingVote = await _voteRepository.FindById(id);

            if (existingVote == null)
                return new VoteResponse("Vote not found");

            existingVote.Name = vote.Name;

            try
            {
                _voteRepository.Update(existingVote);
                await _unitOfWork.CompleteAsync();

                return new VoteResponse(existingVote);
            }
            catch (Exception ex)
            {
                return new VoteResponse($"An error ocurred while updating the vote: {ex.Message}");
            }

        }
    }
}
