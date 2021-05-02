using System;
using System.ComponentModel.DataAnnotations;
//CategoryResources SALIDA - SaveCategoryResources ENTRADA
namespace PosiPrice.API.Resources
{
    public class SaveCategoryResource
    {
        //cumpla condiciones
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
