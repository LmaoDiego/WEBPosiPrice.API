using PosiPrice.API.Domain.Models;
using System;
public class UserVote
{
    public int UserId { get; set; }
    public User User { get; set; }

    /// //////////////////////////////////////

    public int VoteId { get; set; }
    public Vote Vote { get; set; }

}