using System;
using System.ComponentModel;

namespace PosiPrice.API.Domain.Models
{ 
    public enum EUnitOfMeasurement : byte
    {
        [Description("Marca")]
        Marca = 1,
        [Description("Version")]
        Version = 2,
        
        
    }

}
