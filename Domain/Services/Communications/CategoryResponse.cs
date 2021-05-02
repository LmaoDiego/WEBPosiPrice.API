using PosiPrice.API.Domain.Models;
using System;
namespace PosiPrice.API.Domain.Services.Communications
{
    public class CategoryResponse : BaseResponse<Category>
    {
        public CategoryResponse(Category resource) : base(resource)
        {
        }

        public CategoryResponse(string message) : base(message)
        {
        }
    }

}