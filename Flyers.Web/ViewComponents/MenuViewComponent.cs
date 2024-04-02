using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Flyers.Web.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public MenuViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.Run(() =>
            {
                var claim = User.Identity as ClaimsIdentity;
            });       
        
            return View();
        }
    }
}
