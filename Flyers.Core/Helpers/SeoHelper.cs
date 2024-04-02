using System;
using System.Globalization;
using System.Text;

namespace Flyers.Core.Helpers
{
    public static class SeoHelper
    {
        public static string MetaTags(string titulo, string descricao, string palavras, string url)
        {
            StringBuilder metaTags = new StringBuilder();
            //metaTags.Append("<title>" + titulo + "</title>");
            //metaTags.Append(Environment.NewLine);
            metaTags.Append($"<meta name='description' content='{descricao}'/>");
            metaTags.Append(Environment.NewLine);
            metaTags.Append($"<meta name='keywords' content ='{TagKeywords(palavras)}'/>");
            metaTags.Append(Environment.NewLine);
            metaTags.Append($"<meta name='author' content='MoWBI T.I.C' />");
            //og meta tags
            metaTags.Append(Environment.NewLine);
            metaTags.Append($"<meta property='og:title' content = '{titulo}' />");
            metaTags.Append(Environment.NewLine);
            metaTags.Append($"<meta property='og:description' content = '{descricao}' />");
            metaTags.Append(Environment.NewLine);
            metaTags.Append($"<meta property='og:url' content = '{url}' />");
            metaTags.Append(Environment.NewLine);
            return metaTags.ToString();

            /* OG Meta Tags
             * <!-- website name -->
             * <meta property="og:site_name" content="" />
             * <!-- website link -->
             * <meta property="og:site" content="" />
             * <!-- title shown in the actual shared post -->
             * <meta property="og:title" content="" />
             * <!-- description shown in the actual shared post -->
             * <meta property="og:description" content="" />
             * <!-- image link, make sure it's jpg -->
             * <meta property="og:image" content="" />
             * <!-- where do you want your post to link to -->
             * <meta property="og:url" content="" />
             * <meta property="og:type" content="article" />
             */
        }

        public static string TagKeywords(string texto)
        {
            int maxLength = 255;
            if (texto == null)
            {
                return string.Empty;
            }

            var description = texto
                .ToLowerInvariant()
                .Normalize(NormalizationForm.FormD);

            var palavras = new StringBuilder();
            var verifica = false;
            var keywords = "";
            var maxwords = 0;
            char caracter;

            for (int i = 0; i < description.Length; i++)
            {
                caracter = description[i];

                switch (CharUnicodeInfo.GetUnicodeCategory(caracter))
                {
                    case UnicodeCategory.LowercaseLetter:
                    case UnicodeCategory.UppercaseLetter:
                    case UnicodeCategory.DecimalDigitNumber:
                        if (caracter < 128)
                        {
                            palavras.Append(caracter);
                        }
                        else
                        {
                            palavras.Append(TrocaCharParaAscii(caracter));
                        }

                        verifica = false;
                        maxwords = palavras.Length;
                        break;
                    case UnicodeCategory.SpaceSeparator:
                    case UnicodeCategory.ConnectorPunctuation:
                    case UnicodeCategory.DashPunctuation:
                    case UnicodeCategory.OtherPunctuation:
                    case UnicodeCategory.MathSymbol:
                        if (!verifica)
                        {
                            palavras.Append(' ');
                            verifica = true;
                            maxwords = palavras.Length;
                        }
                        break;
                }
                if (maxLength > 0 && maxwords >= maxLength)
                {
                    break;
                }
            }
            foreach (var palavra in (string[])palavras.ToString().Split(' '))
            {
                if (palavra.Length > 4)
                {
                    keywords += $"{palavra},";
                }
            }
            return keywords.Remove(keywords.Length - 1, 1);
            //var urlSeo = palavras.ToString().Trim('-');
            //return maxLength <= 0 || urlSeo.Length <= maxLength ? urlSeo : urlSeo.Substring(0, maxLength);
        }

        private static string TrocaCharParaAscii(char caracter)
        {
            string letra = caracter.ToString().ToLowerInvariant();
            if ("àåáâäãåą".Contains(letra))
            {
                return "a";
            }
            else if ("èéêëę".Contains(letra))
            {
                return "e";
            }
            else if ("ìíîïı".Contains(letra))
            {
                return "i";
            }
            else if ("òóôõöøőð".Contains(letra))
            {
                return "o";
            }
            else if ("ùúûüŭů".Contains(letra))
            {
                return "u";
            }
            else if ("çćčĉ".Contains(letra))
            {
                return "c";
            }
            else if ("żźž".Contains(letra))
            {
                return "z";
            }
            else if ("śşšŝ".Contains(letra))
            {
                return "s";
            }
            else if ("ñń".Contains(letra))
            {
                return "n";
            }
            else if ("ýÿ".Contains(letra))
            {
                return "y";
            }
            else if ("ğĝ".Contains(letra))
            {
                return "g";
            }
            else if (caracter == 'ř')
            {
                return "r";
            }
            else if (caracter == 'ł')
            {
                return "l";
            }
            else if (caracter == 'đ')
            {
                return "d";
            }
            else if (caracter == 'ß')
            {
                return "ss";
            }
            else if (caracter == 'þ')
            {
                return "th";
            }
            else if (caracter == 'ĥ')
            {
                return "h";
            }
            else if (caracter == 'ĵ')
            {
                return "j";
            }
            else
            {
                return "";
            }
        }
    }
}
