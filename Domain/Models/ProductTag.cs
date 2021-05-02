using System;
namespace PosiPrice.API.Domain.Models
{
    //El producto tiene asociada multiples etiquetas. N ... N
    // Ejemplo: Categoria: Tarjetas Graficas: TAG: Nvidia o Radeon
    public class ProductTag
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
       
        /// //////////////////////////////////////
        
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        
    }



}