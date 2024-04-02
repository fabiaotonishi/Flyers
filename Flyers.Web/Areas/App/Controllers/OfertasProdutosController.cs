using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Web.Models;
using Flyers.Web.Areas.App.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Web.Areas.App.Controllers
{
    public class OfertasProdutosController : BaseController
    {
        private readonly ICategoriaDataService _categoriaDataService;
        private readonly IProdutoDataService _produtoDataService;
        private readonly IOfertaProdutoDataService _ofertaProdutoDataService;

        public OfertasProdutosController(
            ILogger<BaseController> logger,
            IHttpContextAccessor httpContextAccessor,
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService,
            ICategoriaDataService categoriaDataService,
            IProdutoDataService produtoDataService,
            IOfertaProdutoDataService ofertaProdutoDataService)
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
            _categoriaDataService = categoriaDataService;
            _produtoDataService = produtoDataService;
            _ofertaProdutoDataService = ofertaProdutoDataService;
        }

        [HttpGet]
        public async Task<IActionResult> ListaAsync(int id)
        {
            try
            {
                TempData["idOferta"] = id;
                var ofertaProdutos = await _ofertaProdutoDataService.ListaPorOfertaAsync(id);
                return PartialView("_Lista", ofertaProdutos);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }            
        }

        [HttpGet]
        public async Task<IActionResult> EditaAsync(int categoria = 0)
        {
            try
            {
                var promocaoProduto = new PromocaoViewModel();
                promocaoProduto.IdCategoria = categoria;
                await AtivaFiltrosAsync(promocaoProduto.IdCategoria);
                return PartialView("_Edita", promocaoProduto);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditaAsync(PromocaoViewModel promocaoProduto)
        {
            try
            {
                if (promocaoProduto.IdCategoria == 0)
                {
                    ModelState.AddModelError("IdCategoria", "Preenchimento é obrigatório");
                }
                if (ModelState.IsValid)
                {
                    var idOferta = (int)TempData["idOferta"];
                    TempData.Keep("idOferta");                    
                    var produtos = await _produtoDataService.ListaPorCategoriaAsync(promocaoProduto.IdCategoria);                    
                    var ofertaProdutos = await _ofertaProdutoDataService
                        .ListaPorOfertaProdutoCategoriaAsync(idOferta, promocaoProduto.IdCategoria);
                    var listaofertaProduto = new List<OfertaProdutoEntity>();
                    if (promocaoProduto.IdProduto > 0)
                    {
                        var produto = produtos
                            .FirstOrDefault(e => e.Id == promocaoProduto.IdProduto);
                        var ofertaProduto = ofertaProdutos
                            .FirstOrDefault(e => e.IdProduto == promocaoProduto.IdProduto);
                        if (ofertaProduto == null)
                        {
                            ofertaProduto = new OfertaProdutoEntity
                            {
                                IdOferta = idOferta,
                                IdProduto = produto.Id,
                                Preco = produto.Preco,
                            };
                        }
                        ofertaProduto.Desconto = promocaoProduto.Desconto;
                        ofertaProduto.CalculaPrecoComDesconto();
                        listaofertaProduto.Add(ofertaProduto);
                    }
                    else
                    {                        
                        foreach (var produto in produtos)
                        {
                            var ofertaProdutoDesconto = new OfertaProdutoEntity();
                            foreach (var ofertaProduto in ofertaProdutos)
                            {
                                if (produto.Id == ofertaProduto.IdProduto)
                                {
                                    ofertaProdutoDesconto = ofertaProduto;
                                }         
                            }
                            ofertaProdutoDesconto.IdOferta = idOferta;
                            ofertaProdutoDesconto.IdProduto = produto.Id;
                            ofertaProdutoDesconto.Preco = produto.Preco;
                            ofertaProdutoDesconto.Desconto = promocaoProduto.Desconto;
                            ofertaProdutoDesconto.CalculaPrecoComDesconto();
                            listaofertaProduto.Add(ofertaProdutoDesconto);
                        }
                    }

                    return Ok(new AppResposta()
                    {
                        Retorno = await _ofertaProdutoDataService.SalvaTodosAsync(listaofertaProduto),
                        Carrega = true,
                        Seletor = "#tab-index-oferta .tab-pane",
                        Url = Url.Action("Lista", "OfertasProdutos", new { area = "App", id = idOferta })
                    });
                }                
                await AtivaFiltrosAsync(promocaoProduto.IdCategoria);
                return PartialView(promocaoProduto);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ApagaAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }
                var ofertaProduto = await _ofertaProdutoDataService.ObtemPorIdAsync(id);
                if (ofertaProduto == null)
                {
                    return NotFound();
                }
                return PartialView("_Apaga", ofertaProduto);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _ApagaAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }
                var idOferta = (int)TempData["idOferta"];
                TempData.Keep("idOferta");
                return Ok(new AppResposta()
                {
                    Retorno = await _ofertaProdutoDataService.ExcluiAsync(id),
                    Carrega = true,
                    Seletor = "#tab-index-oferta .tab-pane",
                    Url = Url.Action("Lista", "OfertasProdutos", new { area = "App", id = idOferta })
                });

            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        private async Task AtivaFiltrosAsync(int categoria)
        {
            try
            {
                var categorias = await _categoriaDataService.ListaAsync();
                ViewBag.Categorias = new SelectList(categorias, "Id", "Nome", categoria);
                if (categoria > 0)
                {
                    var produtos = await _produtoDataService.ListaPorCategoriaAsync(categoria, "Nome asc");
                    ViewBag.Produtos = new SelectList(produtos, "Id", "Nome");
                }
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
            }            
        }
    }
}
