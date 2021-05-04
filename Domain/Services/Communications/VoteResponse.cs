using PosiPrice.API.Domain.Models;
using System;
namespace PosiPrice.API.Domain.Services.Communications
{
    public class VoteResponse : BaseResponse<Vote>
    {
        public VoteResponse(Vote resource) : base(resource)
        {
        }

        public VoteResponse(string message) : base(message)
        {
        }
    }
}