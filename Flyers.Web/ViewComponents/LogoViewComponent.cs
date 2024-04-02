using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Flyers.Web.Models;

namespace Flyers.Web.ViewComponents
{
    public class LogoViewComponent : ViewComponent
    {
        private readonly IArquivoDataService _arquivoDataService;

        public LogoViewComponent(IArquivoDataService arquivoDataService)
        {
            _arquivoDataService = arquivoDataService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int idDominio)
        {
            var logo = new Logo
            {
                Titulo = "Logomarca",
            };
            var imagem = await _arquivoDataService.ObtemImagemAsync(idDominio, PastaValue.Dominio);
            if (imagem != null)
            {
                logo = new Logo
                {
                    Titulo = imagem.Dominio.Nome,
                    Url = imagem.Url
                };
            }
            return View(logo);
        }
    }
}
