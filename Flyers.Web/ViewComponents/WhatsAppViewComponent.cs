using Flyers.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Flyers.Web.ViewComponents
{
    public class WhatsAppViewComponent : ViewComponent
    {
        public WhatsAppViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(string celular, string titular)
        {
            var whatsapp = new WhatsApp();
            await Task.Run(() =>
            {
                whatsapp.Celular = Regex.Replace(celular, @"[^0-9a-zA-Z]+", "");
                whatsapp.Descricao = $"Olá tudo bem! {titular} aguada o seu contato pelo What´s App.";
            });
            return View(whatsapp);
        }
    }
}
