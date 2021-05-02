using System;
using System.Collections.Generic;

namespace PosiPrice.API.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Para que se pueda guardar en un base de datos

        EUnitOfMeasurement UnitOfMeasurement { get; set; }
        
        public short QuantityInPackage { get; set; }

        // Una Categoria 1....... N Productos
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //El producto N.... N Tags
        public List<ProductTag> ProductTags { get; set; }
        
    }


}