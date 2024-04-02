using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Services.ApiServices;
using Flyers.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Flyers.Web.Areas.App.Controllers
{
    public class EnderecosController : BaseController
    {
        private readonly IEnderecoDataService _enderecoDataService;
        private readonly IViacepApiService _viacepApiService;

        public EnderecosController(
            ILogger<BaseController> logger,
            IHttpContextAccessor httpContextAccessor,
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService,
            IEnderecoDataService enderecoDataService,
            IViacepApiService viacepApiService) 
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
            _enderecoDataService = enderecoDataService;
            _viacepApiService = viacepApiService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtemAsync(int id, int dominio)
        {
            try
            {
                //Revisar qdo implementar sessao
                TempData["dominio"] = dominio;
                var endereco = await _enderecoDataService.ObtemPorIdAsync(id);
                if (endereco == null)
                {
                    endereco = new EnderecoEntity();
                }
                return PartialView("_Obtem", endereco);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditaAsync(EnderecoEntity endereco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var idDominio = (int)TempData["dominio"];
                    ModelState.Clear();
                    return Ok(new AppResposta()
                    {
                        Retorno = await _enderecoDataService.SalvaEnderecoDominioAsync(endereco, idDominio)
                    });
                }
                return PartialView(endereco);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> CepAsync(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                return NotFound();
            }
            var apiResposta = await _viacepApiService.GetCepAsync(cep);
            if (!apiResposta.IsSuccessStatusCode)
            {
                return BadRequest("Cep inválido");
            }
            var endereco = apiResposta.Content;
            return Ok(endereco);
        }
    }
}
