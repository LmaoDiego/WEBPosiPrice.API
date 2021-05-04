using System;
using System.Collections.Generic;

namespace PosiPrice.API.Domain.Models
{
    // Etiqueta para identificar un productos en especificos
    public class Vote
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public List<UserVote> UserVotes { get; set; }
    }

}