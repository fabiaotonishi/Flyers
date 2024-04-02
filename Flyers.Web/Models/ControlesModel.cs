using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flyers.Web.Models
{
    public class Busca
    {
        public int Index { get; set; }

        [Display(Name = "Exibe")]
        [Required(ErrorMessage = "Inválido", AllowEmptyStrings = false)]
        [Range(1, int.MaxValue, ErrorMessage = "Inválido")]
        public int Exibe { get; set; }

        [Display(Name = "Pesquisa")]
        public string Pesquisa { get; set; }

        [Display(Name = "Ordem")]
        public string Ordem { get; set; }

        public List<SelectListItem> Ordens { get; set; }

        public Busca()
        {
            Exibe = 50;
            Index = 0;
            Ordem = "Id asc";
        }
    }

    public class AppResposta
    {
        public bool Retorno { get; set; }
        public bool Carrega { get; set; }
        public string Seletor { get; set; }
        public string Url { get; set; }

        public AppResposta()
        {
            Retorno = false;
            Carrega = false;
        }
    }
}
