using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//interacciones con el servicio->servicio
namespace PosiPrice.API.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> GetByIdAsync(int id);
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id); 
    }
}