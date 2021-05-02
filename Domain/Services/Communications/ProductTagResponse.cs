using PosiPrice.API.Domain.Models;
using System;
namespace PosiPrice.API.Domain.Services.Communications
{
    public class ProductTagResponse : BaseResponse<ProductTag>
    {
        public ProductTagResponse(ProductTag resource) : base(resource)
        {
        }

        public ProductTagResponse(string message) : base(message)
        {
        }
    }
}