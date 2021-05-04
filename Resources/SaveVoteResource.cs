using System;
using System.ComponentModel.DataAnnotations;

namespace PosiPrice.API.Resources
{
    public class SaveVoteResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
