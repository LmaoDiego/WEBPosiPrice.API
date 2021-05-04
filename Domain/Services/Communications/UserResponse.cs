using PosiPrice.API.Domain.Models;
using System;
namespace PosiPrice.API.Domain.Services.Communications
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(User resource) : base(resource)
        {
        }

        public UserResponse(string message) : base(message)
        {
        }
    }
}