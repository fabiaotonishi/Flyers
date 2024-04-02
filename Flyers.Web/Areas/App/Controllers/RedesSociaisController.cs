using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using Flyers.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Flyers.Web.Areas.App.Controllers
{
    public class RedesSociaisController : BaseController
    {
        private readonly IRedeSocialDataService _redeSocialDataService;
        public RedesSociaisController(
            ILogger<BaseController> logger,
            IHttpContextAccessor httpContextAccessor,
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService,
            IRedeSocialDataService redeSocialDataService) 
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
            _redeSocialDataService = redeSocialDataService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtemAsync(int dominio, int canal)
        {
            try
            {
                //Revisar qdo implementar sessao
                TempData["dominio"] = dominio;
                var canalSelecionado = (CanalValue)canal;
                TempData["canal"] = canalSelecionado.GetHashCode();
                var redesocial = await _redeSocialDataService.ObtemPorDominioCanalAsync(dominio, canalSelecionado);
                if (redesocial == null)
                {
                    redesocial = new RedeSocialEntity();
                    redesocial.IdDominio = dominio;
                    redesocial.Canal = canalSelecionado;
                }
                return PartialView("_Obtem", redesocial);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }            
        }

        [HttpGet]
        public async Task<IActionResult> EditaAsync(int dominio, int canal)
        {
            try
            {
                //Revisar qdo implementar sessao
                TempData["dominio"] = dominio;
                var canalSelecionado = (CanalValue)canal;
                TempData["canal"] = canalSelecionado.GetHashCode();
                var redesocial = await _redeSocialDataService.ObtemPorDominioCanalAsync(dominio, canalSelecionado);
                if (redesocial == null)
                {
                    redesocial = new RedeSocialEntity();
                    redesocial.IdDominio = dominio;
                    redesocial.Canal = canalSelecionado;
                }
                return PartialView("_Edita", redesocial);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditaAsync(RedeSocialEntity redeSocial)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ModelState.Clear();
                    return Ok(new AppResposta()
                    {
                        Retorno = (await _redeSocialDataService.SalvaAsync(redeSocial) > 0) ? true : false,
                        Carrega = true,
                        Seletor = "#tab-obtem-redesocial .tab-pane",
                        Url = Url.Action("Edita", "RedesSociais", new
                        {
                            area = "App",
                            dominio = redeSocial.IdDominio,
                            canal = redeSocial.Canal.GetHashCode()
                        })
                    });
                }
                return PartialView(redeSocial);
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
                var redeSocial = await _redeSocialDataService.ObtemPorIdAsync(id);
                if (redeSocial == null)
                {
                    return NotFound();
                }
                return PartialView("_Apaga", redeSocial);
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
                var idDominio = (int)TempData["dominio"];
                var idCanal = (int)TempData["canal"];
                return Ok(new AppResposta()
                {
                    Retorno = await _redeSocialDataService.ExcluiAsync(id),
                    Carrega = true,
                    Seletor = "#tab-obtem-redesocial .tab-pane",
                    Url = Url.Action("Edita", "RedesSociais", new
                    {
                        area = "App",
                        dominio = idDominio,
                        canal = idCanal
                    })
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
