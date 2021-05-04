
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Services;
using PosiPrice.API.Extensions;
using PosiPrice.API.Resources;

namespace PosiPrice.API.Controllers
{
    [Route("/api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVoteService _voteService;
        private readonly IMapper _mapper;

        public VotesController(IVoteService voteService, IMapper mapper)
        {
            _voteService = voteService;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IEnumerable<VoteResource>> GetAllAsync()
        {
            var votes = await _voteService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Vote>, IEnumerable<VoteResource>>(votes);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveVoteResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var vote = _mapper.Map<SaveVoteResource, Vote>(resource);
            var result = await _voteService.SaveAsync(vote);

            if (!result.Success)
                return BadRequest(ModelState.GetErrorMessages());

            var voteResource = _mapper.Map<Vote, VoteResource>(result.Resource);

            return Ok(voteResource);

        }
    }
}