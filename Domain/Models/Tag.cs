using System;
using System.Collections.Generic;

namespace PosiPrice.API.Domain.Models
{
    // Etiqueta para identificar un productos en especificos
    public class Tag
    {
        public int Id { get; set; }
        public int Name { get; set; }
           
        public List<ProductTag> ProductTags { get; set; }
    }

}