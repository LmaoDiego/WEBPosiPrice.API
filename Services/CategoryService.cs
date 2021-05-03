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

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindById(id);

            if (existingCategory == null)
                return new CategoryResponse("Category Not Found");

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error ocurred while deleting category: {ex.Message}");
            }

        }

        public async Task<CategoryResponse> GetByIdAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindById(id);

            if (existingCategory == null)
                return new CategoryResponse("Category Not Found");

            return new CategoryResponse(existingCategory);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
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
                return new CategoryResponse($"An error ocurred while saving the category: {ex.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindById(id);

            if (existingCategory == null)
                return new CategoryResponse("Category Not Found");

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"An error ocurred while updating category: {ex.Message}");
            }
        }
    }
}
