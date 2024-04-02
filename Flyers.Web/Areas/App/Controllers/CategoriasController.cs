using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flyers.Core.Entities;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using Microsoft.AspNetCore.Http;
using Flyers.Web.Models;

namespace Flyers.Web.Areas.App.Controllers
{
    public class CategoriasController : BaseController
    {
        private readonly ICategoriaDataService _categoriaDataService;
        public CategoriasController(
            ILogger<CategoriasController> logger,
            IHttpContextAccessor httpContextAccessor,
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService,
            ICategoriaDataService categoriaDataService)
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
            _categoriaDataService = categoriaDataService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var categorias = await _categoriaDataService.ListaAsync();
                if (categorias.Count() > 0)
                {
                    foreach (var categoria in categorias)
                    {
                        categoria.Imagem = await BuscaImagemAsync(categoria.Id, PastaValue.Categoria);
                    }
                }
                return View(categorias);
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
                var categoria = await _categoriaDataService.ObtemPorIdAsync(id);
                if (categoria == null)
                {
                    categoria = new CategoriaEntity();
                }
                categoria.Imagem = await BuscaImagemAsync(categoria.Id, PastaValue.Categoria);
                return View(categoria);
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
                var categoria = await _categoriaDataService.ObtemPorIdAsync(id);
                if (categoria == null)
                {
                    categoria = new CategoriaEntity();
                }
                categoria.Imagem = await BuscaImagemAsync(categoria.Id, PastaValue.Categoria);
                return PartialView("_Obtem", categoria);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }            
        }

        public async Task<IActionResult> EditaAsync(int id)
        {
            try
            {
                var categoria = await _categoriaDataService.ObtemPorIdAsync(id);
                return PartialView("_Edita", categoria);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditaAsync(CategoriaEntity categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ModelState.Clear();
                    var idCategoria = await _categoriaDataService.SalvaAsync(categoria);
                    return Ok(new AppResposta()
                    {
                        Retorno = (idCategoria > 0) ? true : false,
                        Url = Url.Action("Exibe", "Categorias", new { area = "App", id = idCategoria })
                    });
                    //return Ok(new AppResposta()
                    //{
                    //    Retorno = (await _categoriaDataService.SalvaAsync(categoria) > 0) ? true : false
                    //});
                }
                return PartialView(categoria);
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
                var categoria = await _categoriaDataService.ObtemPorIdAsync(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                return PartialView("_Apaga", categoria);
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
                    Retorno = await _categoriaDataService.ExcluiAsync(id)
                });
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }
    }
}
