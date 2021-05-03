using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Persistence.Repositories;
using PosiPrice.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosiPrice.API.Services
{
    public class ProductService : IProductService
    {
        //Service interactua con repository (product y producttag
        private readonly IProductRepository _productRepository;
        private readonly IProductTagRepository _productTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _productTagRepository = productTagRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId)
        {
            return await _productRepository.ListByCategoryIdAsync(categoryId);
        }

        public async Task<IEnumerable<Product>> ListByTagIdAsync(int tagId)
        {
            var productTags = await _productTagRepository.ListByTagIdAsync(tagId);
            var products = productTags.Select(pt => pt.Product).ToList();
            return products;
        }
    }
}
