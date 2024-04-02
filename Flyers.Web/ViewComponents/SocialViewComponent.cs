using Flyers.Core.Interfaces.DataServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Flyers.Web.ViewComponents
{
    public class SocialViewComponent : ViewComponent
    {
        private readonly IRedeSocialDataService _redeSocialDataService;

        public SocialViewComponent(IRedeSocialDataService redeSocialDataService)
        {
            _redeSocialDataService = redeSocialDataService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int idDominio)
        {
            var redesociais = await _redeSocialDataService.ListaAsync(idDominio);
            return View(redesociais);
        }
    }
}
