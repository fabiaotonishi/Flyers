using Flyers.Core.Interfaces.DataServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Flyers.Web.Controllers
{
    public class MidiaController : BaseController
    {
        public MidiaController(
            ILogger<MidiaController> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IDominioDataService dominioDataService, 
            IArquivoDataService arquivoDataService) 
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ImagemAsync(string nome)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nome))
                {
                    return NotFound();
                }

                var midia = await _arquivoDataService.ObtemImagemAsync(nome);
                return File(midia.Dados, midia.Tipo);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }
    }
}
