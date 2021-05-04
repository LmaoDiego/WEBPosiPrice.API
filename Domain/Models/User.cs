using System;
using System.Collections.Generic;

namespace PosiPrice.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Para que se pueda guardar en un base de datos

       
        //El producto N.... N Tags
        public List<UserVote> UserVotes { get; set; }

    }


}