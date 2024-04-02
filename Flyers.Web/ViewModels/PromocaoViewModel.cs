using Flyers.Core.Dtos.DataTables;
using Flyers.Core.Entities;
using Flyers.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Flyers.Web.ViewModels
{
    public class PromocaoViewModel
    {
        public OfertaEntity Detalhes { get; set; }
        public OfertaProdutoDataTableDto Listagem { get; set; }
        public Busca Pesquisa { get; set; }
        //public BuscaModel Pesquisa => BuscaPesquisa();
        public IEnumerable<CategoriaEntity> Exibicao { get; set; }
        //public IEnumerable<CategoriaEntity> Exibicao => Listagem.ListaCategorias();

        public PromocaoViewModel()
        {
            Pesquisa = new Busca()
            {
                Index = 0,
                Exibe = 12,
                Ordem = "PrecoDesconto asc",
                Ordens = new List<SelectListItem> {
                    new SelectListItem { Value = "PrecoDesconto asc", Text = "Preço crescente" },
                    new SelectListItem { Value = "PrecoDesconto desc", Text = "Preço decrescente" }
                }
            };
        }

        //private BuscaModel BuscaPesquisa()
        //{
        //    return new BuscaModel()
        //    {
        //        Index = 0,
        //        Exibe = 12,
        //        Ordem = "PrecoDesconto asc",
        //        Ordens = new List<SelectListItem> {
        //            new SelectListItem { Value = "PrecoDesconto asc", Text = "Preço crescente" },
        //            new SelectListItem { Value = "PrecoDesconto desc", Text = "Preço decrescente" }
        //        }
        //    };
        //}
    }
}
