using System;
namespace PosiPrice.API.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }
        public string UnitOfMeasurement { get; set; }
        //**//
        public SaveCategoryResource Category { get; set; }
    }
}