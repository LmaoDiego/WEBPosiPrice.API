using PosiPrice.API.Domain.Models;
using PosiPrice.API.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PosiPrice.API.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Product>> ListByTagIdAsync(int tagId);
    }
}
