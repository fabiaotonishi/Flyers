using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Flyers.Core.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Extensão para criptografar em MD5 a string
        /// </summary>
        public static string ToMd5(this string texto)
        {
            try
            {
                MD5 md5 = MD5.Create();
                var bitExpressao = Encoding.ASCII.GetBytes(texto);
                var bitMd5Hash = md5.ComputeHash(bitExpressao);
                StringBuilder strCriptografado = new StringBuilder();
                for (int i = 0; i < bitMd5Hash.Length; i++)
                {
                    strCriptografado.Append(bitMd5Hash[i].ToString("X2"));
                }
                return strCriptografado.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Extensão para ajustar o texto da Url
        /// </summary>
        public static string ToUrl(this string texto)
        {            
            texto = (texto + " ").ToLower();
            var retorno = texto.Remove(texto.Length - 1);
            return Regex.Replace(retorno, "[^a-zA-Z0-9_]+", "-");
        }

        /// <summary>
        /// Extensão para remover acentos do texto
        /// </summary>
        public static string ToSemAcento(this string texto)
        {
            StringBuilder palavra = new StringBuilder();
            foreach (char letra in texto.Normalize(NormalizationForm.FormD))
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letra) != UnicodeCategory.NonSpacingMark)
                    palavra.Append(letra);
            }
            return palavra.ToString();
        }
    }
}