using System;
using System.ComponentModel.DataAnnotations;

namespace Flyers.Web.Areas.App.ViewModels
{
    public class PromocaoViewModel
    {
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }

        [Display(Name = "Produto")]
        public int IdProduto { get; set; }

        [Display(Name = "Desconto (%)")]        
        [Range(0.00, 100.00, ErrorMessage= "Inválido")]
        [DisplayFormat(DataFormatString="{0:##.##}")]
        public decimal Desconto { get; set; }
    }
}
