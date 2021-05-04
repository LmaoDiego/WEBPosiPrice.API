using System;
using System.ComponentModel.DataAnnotations;

namespace PosiPrice.API.Domain.Resources
{   
    public class SaveUserResource
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
