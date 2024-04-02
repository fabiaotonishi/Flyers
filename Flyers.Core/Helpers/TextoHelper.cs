using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Flyers.Core.Helpers
{
    public static class TextoHelper
    {
        public static string SomenteNumeros(this string str, string texto)
        {
            return new string(texto.Where(char.IsDigit).ToArray());
        }

        public static string RemoveMascara(this string str, string texto)
        {
            return texto.Replace(".", "").Replace("-", "").Replace(" ", "").Replace("/", "");
        }

        public static string RemoveTagHTML(this string str, string texto)
        {
            return Regex.Replace(texto, "<.*?>", String.Empty);
        }
    }
}
