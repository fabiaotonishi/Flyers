using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Flyers.Core.Helpers;

namespace Flyers.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IEnderecoDataService _enderecoDataService;

        public HomeController(
            ILogger<HomeController> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService,
            IEnderecoDataService enderecoDataService) 
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
            _enderecoDataService = enderecoDataService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var dominio = sessaoAtual.GetObject<DominioEntity>("Dominio");
            if (dominio == null)
            {
                RedirectToAction("Cadastro");
            }
            dominio.Endereco = await _enderecoDataService
                    .ObtemPorIdAsync(dominio.IdEndereco.GetValueOrDefault());
            ViewData["Title"] = dominio.Nome;
            ViewData["Metas"] = SeoHelper.MetaTags(
                $"Home - {dominio.Nome}",
                dominio.Descricao,
                dominio.Nome,
                dominio.Video);
            return View(dominio);
        }

        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
