using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Flyers.Web.Controllers
{
    public class SobrenosController : BaseController
    {
        public SobrenosController(
            ILogger<BaseController> logger,
            IHttpContextAccessor httpContextAccessor,
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService)
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
        }

        public IActionResult Detalhes()
        {
            var dominio = sessaoAtual.GetObject<DominioEntity>("Dominio");
            return PartialView("_Detalhes", dominio);
        }
    }
}
