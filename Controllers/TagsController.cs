using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Services;
using PosiPrice.API.Extensions;
using PosiPrice.API.Resources;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagsController(ITagService tagService, IMapper mapper)
        {
            _tagService = tagService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TagResource>> GetAllAsync()
        {
            var tags = await _tagService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagResource>>(tags);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTagResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var tag = _mapper.Map<SaveTagResource, Tag>(resource);
            var result = await _tagService.SaveAsync(tag);

            if (!result.Success)
                return BadRequest(ModelState.GetErrorMessages());

            var tagResource = _mapper.Map<Tag, TagResource>(result.Resource);

            return Ok(tagResource);

        }
    }
}
