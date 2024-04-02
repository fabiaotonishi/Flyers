using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using Flyers.Web.Extensions;
using Flyers.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Web.Areas.App.Controllers
{
    public class OfertasController : BaseController
    {
        private readonly IOfertaDataService _ofertaDataService;

        public OfertasController(
            ILogger<BaseController> logger,
            IHttpContextAccessor httpContextAccessor,
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService,
            IOfertaDataService ofertaDataService) 
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
            _ofertaDataService = ofertaDataService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var ofertas = await _ofertaDataService.ListaAsync();
                if (ofertas.Count() > 0)
                {
                    foreach (var oferta in ofertas)
                    {
                        oferta.Imagem = await BuscaImagemAsync(oferta.Id, PastaValue.Oferta);
                    }
                }
                return View(ofertas);
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
                var oferta = await _ofertaDataService.ObtemPorIdAsync(id);
                if (oferta == null)
                {
                    oferta = new OfertaEntity();
                    oferta.IdDominio = sessaoAtual.GetObject<DominioEntity>("Dominio").Id;
                }
                oferta.Imagem = await BuscaImagemAsync(oferta.Id, PastaValue.Oferta);
                return View(oferta);
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
                var oferta = await _ofertaDataService.ObtemPorIdAsync(id);
                if (oferta == null)
                {
                    oferta = new OfertaEntity();
                    oferta.IdDominio = sessaoAtual.GetObject<DominioEntity>("Dominio").Id;
                }
                oferta.Imagem = await BuscaImagemAsync(oferta.Id, PastaValue.Oferta);
                return PartialView("_Obtem", oferta);
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
                var oferta = await _ofertaDataService.ObtemPorIdAsync(id);
                if (oferta == null)
                {
                    oferta = new OfertaEntity();
                    oferta.IdDominio = sessaoAtual.GetObject<DominioEntity>("Dominio").Id;
                }
                return PartialView("_Edita", oferta);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditaAsync(OfertaEntity oferta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ModelState.Clear();
                    var idOferta = await _ofertaDataService.SalvaAsync(oferta);
                    return Ok(new AppResposta()
                    {
                        Retorno = (idOferta > 0) ? true : false,
                        Url = Url.Action("Exibe", "Ofertas", new { area = "App", id = idOferta })
                    });
                    //return Ok(new AppResposta()
                    //{
                    //    Retorno = (await _ofertaDataService.SalvaAsync(oferta) > 0) ? true : false
                    //});
                }
                return PartialView(oferta);
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

                var oferta = await _ofertaDataService.ObtemPorIdAsync(id);
                if (oferta == null)
                {
                    return NotFound();
                }

                return PartialView("_Apaga", oferta);
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
                    Retorno = await _ofertaDataService.ExcluiAsync(id)
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

