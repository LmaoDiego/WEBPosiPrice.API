using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Services;
using PosiPrice.API.Resources;

namespace PosiPrice.API.Controllers
{
    [Route("/api/users/{userId}/votes")]
    public class UserVotesController : ControllerBase
    {
        private readonly IVoteService _voteService;
        private readonly IUserVoteService _userVoteService;
        private readonly IMapper _mapper;

        public UserVotesController(IVoteService voteService, IUserVoteService userVoteService, IMapper mapper)
        {
            _voteService = voteService;
            _userVoteService = userVoteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<VoteResource>> GetAllByUserTdAsync(int userId)
        {
            var votes = await _voteService.ListByUserIdAsync(userId);
            var resources = _mapper.Map<IEnumerable<Vote>, IEnumerable<VoteResource>>(votes);

            return resources;
        }

        [HttpPost("{voteId}")]
        public async Task<IActionResult> AssignUserVote(int userId, int voteId)
        {
            var result = await _userVoteService.AssignUserVoteAsync(userId, voteId);

            if (!result.Success)
                return BadRequest(result.Message);

            var voteResource = _mapper.Map<Vote, VoteResource>(result.Resource.Vote);

            return Ok(voteResource);
        }
    }
}
