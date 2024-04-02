using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using Flyers.Web.Extensions;
using Flyers.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Web.Areas.App.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly ICategoriaDataService _categoriaDataService;
        private readonly IProdutoDataService _produtoDataService;
        public ProdutosController(
            ILogger<BaseController> logger,
            IHttpContextAccessor httpContextAccessor,
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService,
            ICategoriaDataService categoriaDataService,
            IProdutoDataService produtoDataService) 
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
            _categoriaDataService = categoriaDataService;
            _produtoDataService = produtoDataService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var produtos = await _produtoDataService.ListaAsync(e => e.Dominio, e => e.Categoria);
                if (produtos.Count() > 0)
                {
                    foreach (var produto in produtos)
                    {
                        produto.Imagem = await BuscaImagemAsync(produto.Id, PastaValue.Produto);
                    }
                }
                return View(produtos);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        public async Task<IActionResult> ExibeAsync(int id)
        {
            try
            {
                var produto = await _produtoDataService.ObtemPorIdAsync(id);
                if (produto == null)
                {
                    produto = new ProdutoEntity();
                    produto.IdDominio = sessaoAtual.GetObject<DominioEntity>("Dominio").Id;
                    produto.IdCategoria = 0;
                }
                produto.Imagem = await BuscaImagemAsync(produto.Id, PastaValue.Produto);
                await AtivaFiltrosAsync(produto.IdCategoria);
                return View(produto);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        public async Task<IActionResult> ObtemAsync(int id)
        {
            try
            {
                var produto = await _produtoDataService.ObtemPorIdAsync(id);
                if (produto == null)
                {
                    produto = new ProdutoEntity();
                    produto.IdDominio = sessaoAtual.GetObject<DominioEntity>("Dominio").Id;
                    produto.IdCategoria = 0;
                }
                produto.Imagem = await BuscaImagemAsync(produto.Id, PastaValue.Produto);
                await AtivaFiltrosAsync(produto.IdCategoria);
                return PartialView("_Obtem", produto);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditaAsync(int id)
        {
            try
            {
                var produto = await _produtoDataService.ObtemPorIdAsync(id);
                if (produto == null)
                {
                    produto = new ProdutoEntity();
                    produto.IdDominio = sessaoAtual.GetObject<DominioEntity>("Dominio").Id;
                }
                await AtivaFiltrosAsync(produto.IdCategoria);
                return PartialView("_Edita", produto);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditaAsync(ProdutoEntity produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ModelState.Clear();
                    var idProduto = await _produtoDataService.SalvaAsync(produto);
                    return Ok(new AppResposta()
                    {
                        Retorno = (idProduto > 0) ? true : false,
                        Url = Url.Action("Exibe", "Produtos", new { area = "App", id = idProduto })
                    });
                    //return Ok(new AppResposta()
                    //{
                    //    Retorno = (await _produtoDataService.SalvaAsync(produto) > 0) ? true : false
                    //});
                }
                await AtivaFiltrosAsync(produto.IdCategoria);
                return PartialView(produto);
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

                var produto = await _produtoDataService.ObtemPorIdAsync(id);
                if (produto == null)
                {
                    return NotFound();
                }

                return PartialView("_Apaga", produto);
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

                return Ok(new AppResposta()
                {
                    Retorno = await _produtoDataService.ExcluiAsync(id),
                    Carrega = false
                });

            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
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
    }
}
