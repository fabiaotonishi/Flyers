using Flyers.Web.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Flyers.Web.Areas.App.ViewModels
{
    public class ImagemViewModel
    {
        public int Entidade { get; set; }
        public int Pasta { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public string Dados { get; set; }

        [Display(Name = "Imagem")]
        [Required(ErrorMessage = "Imagem não informada")]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg", ".gif", ".svg" })]
        [DataType(DataType.Upload)]
        public IFormFile Arquivo { get; set; }
    }
}
