using Flyers.Core.Interfaces.DataServices;
using Flyers.Web.Areas.App.ViewModels;
using Flyers.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;

namespace Flyers.Web.Areas.App.Controllers
{
    public class AparenciaController : BaseController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AparenciaController(
            ILogger<BaseController> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IDominioDataService dominioDataService, 
            IArquivoDataService arquivoDataService,
            IWebHostEnvironment webHostEnvironment) 
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            var layout = new LayoutViewModel();
            return View(layout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _EditaAsync(LayoutViewModel layout)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (layout.Arquivo.Length == 0)
                    {
                        return BadRequest();
                    }
                    //string contentRootPath = _webHostEnvironment.ContentRootPath;
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    string pathImagens = Path.Combine(webRootPath, "img");
                    if (!Directory.Exists(pathImagens))
                    {
                        Directory.CreateDirectory(pathImagens);
                    }
                    string nome = Path.GetFileName(layout.Arquivo.FileName);
                    switch (layout.Sessao)
                    {
                        case 1:
                            nome = "bg01.jpg";
                            break;
                        case 2:
                            nome = "bg02.jpg";
                            break;
                        case 3:
                            nome = "bg03.jpg";
                            break;
                        case 4:
                            nome = "bg04.jpg";
                            break;
                            //default:
                            //    nome = "bg00.jpg";
                            //    break;
                    }
                    using (FileStream stream = new FileStream(Path.Combine(pathImagens, nome), FileMode.Create))
                    {
                        layout.Arquivo.CopyTo(stream);
                    }
                    return Ok(new AppResposta()
                    {
                        Retorno = true,
                    });
                }
                return PartialView(layout);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }
    }

}
