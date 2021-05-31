using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PosiPrice.API.Resources;
using PosiPrice.API.Domain.Services;
using AutoMapper;
using PosiPrice.API.Domain.Models;

using PosiPrice.API.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace PosiPrice.API.Controllers
{   
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        
        [SwaggerResponse(200, "List of Categories", typeof(IEnumerable<CategoryResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryResource>), 200)]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();

            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

            return resources;

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
            return Ok(categoryResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);

            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);

            return Ok(categoryResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);

            return Ok(categoryResource);

        }

    }
}