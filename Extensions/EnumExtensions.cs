using System;
using System.Reflection;
using System.ComponentModel;
namespace PosiPrice.API.Domain.Models
{
    public static class EnumExtensions
    {
        public static string ToDescriptionString<TEnum>(this TEnum @enum)
        {
            FieldInfo info = @enum.GetType().GetField(@enum.ToString());
            //cast -> Si existe una descripcion entonces devuelve la descripcion sino el nombre del enumation en string  
            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            return attributes?[0].Description ?? @enum.ToString();

        }
    }
}