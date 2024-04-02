using Flyers.Core.Interfaces.DataServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Flyers.Web.Areas.App.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(
            ILogger<BaseController> logger,
            IHttpContextAccessor httpContextAccessor,
            IDominioDataService dominioDataService,
            IArquivoDataService arquivoDataService) 
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
