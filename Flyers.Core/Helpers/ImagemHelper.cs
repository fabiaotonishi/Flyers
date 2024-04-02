using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Flyers.Core.Helpers
{
    public static class ImagemHelper
    {
        /// <summary>
        /// Método de conversão de imagem em Bytes Array para String Base64
        /// </summary>
        /// <param name="imagemArray">Bytes Array</param>
        /// <returns>String Base64</returns>
        public static string ImagemBase64(string imagemTipo, byte[] imagemArray)
        {
            string arquivoB64 = Convert.ToBase64String(imagemArray);
            string arquivoUrl = string.Format("data:{0};base64,{1}", imagemTipo, arquivoB64);
            return arquivoUrl;
        }

        /// <summary>
        /// Método de conversão de imagem Base64 para Byte Array
        /// </summary>
        /// <param name="imagemArray">Bytes Array</param>
        /// <returns>String Base64</returns>
        public static byte[] ImagemByteArray(string imagemBase64)
        {
            var arquivoB64 = Regex.Match(imagemBase64, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            return Convert.FromBase64String(arquivoB64);
        }

        private static Image RecortaImage(Image sourceImage, int sourceX, int sourceY, int sourceWidth, int sourceHeight, int destinationWidth, int destinationHeight)
        {
            Image bitmap = new Bitmap(destinationWidth, destinationHeight);
            using (Graphics g = Graphics.FromImage(bitmap))
                g.DrawImage(
                  sourceImage,
                  new Rectangle(0, 0, destinationWidth, destinationHeight),
                  new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                  GraphicsUnit.Pixel
                );

            return bitmap;
        }
    }
}
