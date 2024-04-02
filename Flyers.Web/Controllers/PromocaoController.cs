using Flyers.Core.Dtos.DataTables;
using Flyers.Core.Entities;
using Flyers.Core.Helpers;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using Flyers.Web.Models;
using Flyers.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Web.Controllers
{
    public class PromocaoController : BaseController
    {
        private readonly IOfertaDataService _ofertaDataService;
        private readonly ICategoriaDataService _categoriaDataService;
        private readonly IOfertaProdutoDataService _ofertaProdutoDataService;

        public PromocaoController(
            ILogger<PromocaoController> logger,
            IHttpContextAccessor httpContextAccessor,
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService,
            IOfertaDataService ofertaDataService,
            ICategoriaDataService categoriaDataService,
            IOfertaProdutoDataService ofertaProdutoDataService)
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
            _ofertaDataService = ofertaDataService;
            _categoriaDataService = categoriaDataService;
            _ofertaProdutoDataService = ofertaProdutoDataService;
        }

        [HttpGet]
        [Route("/promocao/{id}/{slug}")]
        public async Task<IActionResult> IndexAsync(int id, string slug)
        {
            TempData["idOferta"] = id;
            TempData["idCategoria"] = 0;
            var promocao = new PromocaoViewModel();
            promocao.Detalhes = await ObtemOfertaAsync(id);
            promocao.Exibicao = await ListaCategoriaAsync();
            promocao.Listagem = await ListaOfertaProdutosAsync(
                id, 
                0, 
                promocao.Pesquisa);
            AtivaMetaSeo(promocao);
            await AtivaFiltrosAsync(0);
            return View(promocao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PesquisaAsync(Busca busca, int categoria)
        {
            if (ModelState.IsValid)
            {
                TempData.Keep("idOferta");
                int oferta = (int)TempData["idOferta"];
                var ofertaProdutosDto = await ListaOfertaProdutosAsync(
                    oferta,
                    categoria,
                    busca);
                if (ofertaProdutosDto.TabelaTotal == 0)
                {
                    return NotFound();
                }
                await AtivaFiltrosAsync(categoria);
                return PartialView("_Listagem", ofertaProdutosDto);
            }
            return PartialView(busca);
        }

        public async Task<IActionResult> DestaqueAsync(int exibe = 8)
        {
            try
            {
                var ofertas = await _ofertaDataService.ListaPorDataTerminoAsync(
                    DateTime.Now.AddDays(30),
                    0,
                    exibe,
                    "Termino asc");
                if (ofertas.Count() > 0)
                {
                    foreach (var oferta in ofertas)
                    {
                        oferta.Imagem = await BuscaImagemAsync(oferta.Id, PastaValue.Oferta);
                    }
                }
                return PartialView("_Destaque", ofertas);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        private async Task<OfertaEntity> ObtemOfertaAsync(int idOferta)
        {
            try
            {
                var oferta = await _ofertaDataService.ObtemPorIdAsync(idOferta);
                if (oferta != null)
                {
                    oferta.Imagem = await BuscaImagemAsync(oferta.Id, PastaValue.Oferta);
                }
                return oferta;
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return null;
            }
        }

        private async Task<OfertaProdutoDataTableDto> ListaOfertaProdutosAsync(int idOferta, int idCategoria, Busca busca)
        {
            try
            {
                var ofertaProdutoDto = new OfertaProdutoDataTableDto();
                if (idCategoria == 0)
                {
                    ofertaProdutoDto = await _ofertaProdutoDataService.ListaPorFiltroAsync(
                    idOferta,
                    busca.Pesquisa,
                    busca.Index,
                    busca.Exibe,
                    busca.Ordem);
                }
                else
                {
                    ofertaProdutoDto = await _ofertaProdutoDataService.ListaPorFiltroAsync(
                    idOferta,
                    idCategoria,
                    busca.Pesquisa,
                    busca.Index,
                    busca.Exibe,
                    busca.Ordem);
                }
                if (ofertaProdutoDto.TabelaTotal > 0)
                {
                    foreach (var ofertaProduto in ofertaProdutoDto.Tabela)
                    {
                        ofertaProduto.Produto.Imagem = await BuscaImagemAsync(
                            ofertaProduto.Produto.Id,
                            PastaValue.Produto);
                    }
                }
                return ofertaProdutoDto;
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return null;
            }
        }

        private async Task<IEnumerable<CategoriaEntity>> ListaCategoriaAsync()
        {
            try
            {
                var categorias = await _categoriaDataService.ListaAsync();
                if (categorias.Count() > 0)
                {
                    foreach (var categoria in categorias)
                    {
                        categoria.Imagem = await BuscaImagemAsync(
                            categoria.Id,
                            PastaValue.Categoria);
                    }
                }
                return categorias;
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return null;
            }
        }

        private async Task AtivaFiltrosAsync(int idCategoria)
        {
            try
            {
                var categorias = await _categoriaDataService.ListaAsync();
                ViewBag.Categorias = new SelectList(categorias, "Id", "Nome", idCategoria);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
            }
        }

        private void AtivaMetaSeo(PromocaoViewModel promocao)
        {
            ViewData["Title"] = $"Promoção - {promocao.Detalhes.Nome}";
            ViewData["Metas"] = SeoHelper.MetaTags(
                $"Promoção - {promocao.Detalhes.Nome}",
                promocao.Detalhes.Descricao,
                promocao.Detalhes.Nome,
                Url.Action("Index", "Promocao"));
        }
    }
}
