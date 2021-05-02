using System;
using System.Collections.Generic;

namespace PosiPrice.API.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Products sera la lista de productos
        public IList<Product> Products { get; set; } = new List<Product>();
    }




}