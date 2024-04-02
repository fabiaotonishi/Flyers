using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Flyers.Web.Controllers
{
    public class ContatosController : BaseController
    {
        private readonly IEnderecoDataService _enderecoDataService;

        public ContatosController(
            ILogger<BaseController> logger,
            IHttpContextAccessor httpContextAccessor,
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService,
            IEnderecoDataService enderecoDataService)
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
            _enderecoDataService = enderecoDataService;
        }

        public async Task<IActionResult> DetalhesAsync()
        {
            try
            {
                var dominio = sessaoAtual.GetObject<DominioEntity>("Dominio");
                if (dominio != null)
                {
                    dominio.Endereco = await _enderecoDataService
                        .ObtemPorIdAsync(dominio.IdEndereco.GetValueOrDefault());
                }
                else
                {
                    return BadRequest();
                }
                return PartialView("_Detalhes", dominio);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }
    }
}
