using Flyers.Core.Entities;
using Flyers.Core.Helpers;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using Flyers.Web.Extensions;
using Flyers.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Web.Controllers
{
    public abstract class BaseController : Controller
    {        
        protected readonly ILogger<BaseController> _logger;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IDominioDataService _dominioDataService;
        protected readonly IArquivoDataService _arquivoDataService;

        public BaseController(
            ILogger<BaseController> logger,
            IHttpContextAccessor httpContextAccessor,
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _dominioDataService = dominioDataService;
            _arquivoDataService = arquivoDataService;
            AtivaSessaoCliente();
        }

        protected ISession sessaoAtual => _httpContextAccessor.HttpContext.Session;

        private void AtivaSessaoCliente()
        {
            if (sessaoAtual.GetObject<DominioEntity>("Dominio") == null)
            {
                var dominios = _dominioDataService.ListaAsync().Result;
                sessaoAtual.SetObject("Dominio", dominios.FirstOrDefault());
            }
        }

        protected async Task<ArquivoEntity> BuscaImagemAsync(int idEntidade, PastaValue pasta)
        {
            try
            {
                var imagem = await _arquivoDataService.ObtemImagemAsync(idEntidade, pasta);
                if (imagem == null)
                {
                    imagem = new ArquivoEntity
                    {
                        Id = 0,
                        Entidade = idEntidade,
                        Pasta = pasta,
                        Nome = "image",
                        Url = "/img/image.svg"
                    };
                }
                else
                {
                    imagem.Url = ImagemHelper.ImagemBase64(imagem.Tipo, imagem.Dados);
                }
                return imagem;
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return null;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
