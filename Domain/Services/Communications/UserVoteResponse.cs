using PosiPrice.API.Domain.Models;
using System;
namespace PosiPrice.API.Domain.Services.Communications
{
    public class UserVoteResponse : BaseResponse<UserVote>
    {
        public UserVoteResponse(UserVote resource) : base(resource)
        {
        }

        public UserVoteResponse(string message) : base(message)
        {
        }
    }
}