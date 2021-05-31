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
    [Route("/api/categories/{categoryId}/products")]
    public class CategoryProductsController
    {
        private IProductService _productService;
        private readonly IMapper _mapper;

        public CategoryProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllByCategoryIdAsync(int categoryId)
        {
            var products = await _productService.ListByCategoryIdAsync(categoryId);
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return resources;
        }
    }
}
