using System;
using System.Linq;
namespace PosiPrice.API.Domain.Models
{
    public static class StringExtension
    {
        // SssSsss, sss_ssss -SnakeCase
        public static string ToSnakeCase(this string str)
        {
            return string.Concat(

                str.Select((x, i) => i > 0 &&
                char.IsUpper(x) ? "_" + x.ToString() :
                x.ToString())).ToLower();
                
        }

    }

}