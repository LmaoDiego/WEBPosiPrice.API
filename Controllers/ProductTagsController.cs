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
    [Route("/api/products/{productId}/tags")]
    public class ProductTagsController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IProductTagService _productTagService;
        private readonly IMapper _mapper;

        public ProductTagsController(ITagService tagService, IProductTagService productTagService, IMapper mapper)
        {
            _tagService = tagService;
            _productTagService = productTagService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TagResource>> GetAllByProductTdAsync(int productId)
        {
            var tags = await _tagService.ListByProductIdAsync(productId);
            var resources = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagResource>>(tags);

            return resources;
        }

        [HttpPost("{tagId}")]
        public async Task<IActionResult> AssignProductTag(int productId, int tagId)
        {
            var result = await _productTagService.AssignProductTagAsync(productId, tagId);

            if (!result.Success)
                return BadRequest(result.Message);

            var tagResource = _mapper.Map<Tag, TagResource>(result.Resource.Tag);

            return Ok(tagResource);
        }
    }
}
