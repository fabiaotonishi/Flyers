using Flyers.Web.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flyers.Web.Areas.App.ViewModels
{
    public class LayoutViewModel
    {
        public int Sessao { get; set; }
        public List<SelectListItem> Sessoes { get; set; }

        [Display(Name = "Arquivo")]
        [Required(ErrorMessage = "Arquivo não informado")]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg", ".gif" })]
        [DataType(DataType.Upload)]
        public IFormFile Arquivo { get; set; }

        public LayoutViewModel()
        {
            Sessoes = new List<SelectListItem> {
                //new SelectListItem { Value = "0", Text = "Principal"},
                new SelectListItem { Value = "1", Text = "Promoção"},
                new SelectListItem { Value = "2", Text = "Sobre-nós"},
                new SelectListItem { Value = "3", Text = "Produtos"},
                new SelectListItem { Value = "4", Text = "Contatos"}
            };
        }
    }
}
