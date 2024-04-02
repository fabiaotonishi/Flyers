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
using System.Threading.Tasks;

namespace Flyers.Web.Areas.App.Controllers
{
    public class DominiosController : BaseController
    {       
        public DominiosController(
            ILogger<BaseController> logger,
            IHttpContextAccessor httpContextAccessor,
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService) 
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                //sessao do dominio ativo
                var dominio = sessaoAtual.GetObject<DominioEntity>("Dominio");
                if (dominio == null)
                {
                    return RedirectToAction("Finaliza", "Conta", new { area = "Default" });
                }
                dominio.Imagem = await BuscaImagemAsync(dominio.Id, PastaValue.Dominio);
                return View(dominio);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }          
        }

        [HttpGet]
        public async Task<IActionResult> ObtemAsync(int id)
        {
            try
            {
                //edicao do dominio ativo
                var dominioSessao = sessaoAtual.GetObject<DominioEntity>("Dominio");
                var dominioEdicao = await _dominioDataService.ObtemPorIdAsync(id);
                if (dominioEdicao == null || dominioEdicao.Id != dominioSessao.Id)
                {
                    return RedirectToAction("Finaliza", "Conta", new { area = "Default" });
                }
                dominioEdicao.Imagem = await BuscaImagemAsync(dominioEdicao.Id, PastaValue.Dominio);
                return PartialView("_Obtem", dominioEdicao);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditaAsync(DominioEntity dominio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ModelState.Clear();
                    var idDominio = await _dominioDataService.SalvaAsync(dominio);
                    return Ok(new AppResposta()
                    {
                        Retorno = (idDominio > 0) ? true : false,
                        Carrega = true,
                        Seletor = "#tab-index-dominio .tab-pane",
                        Url = Url.Action("Obtem", "Dominios", new { area = "App", id = idDominio })
                    });
                }
                return PartialView(dominio);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }
    }
}
