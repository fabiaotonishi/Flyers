using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Flyers.Web.ViewComponents
{
    public class PerfilViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.Run(() =>
            {
                //tarefa
            });

            return View();
        }
    }
}
