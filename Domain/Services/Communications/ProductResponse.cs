using PosiPrice.API.Domain.Models;
using System;
namespace PosiPrice.API.Domain.Services.Communications
{
    public class ProductResponse : BaseResponse<Product>
    {
        public ProductResponse(Product resource) : base(resource)
        {
        }

        public ProductResponse(string message) : base(message)
        {
        }
    }
}
