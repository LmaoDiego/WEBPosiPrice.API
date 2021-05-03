using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Persistence.Repositories;
using PosiPrice.API.Domain.Services;
using PosiPrice.API.Domain.Services.Communications;

namespace PosiPrice.API.Services
{
  public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<CategoryResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error ocurred while saving the category :{ex.Message}");
            }
        }

        public Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
