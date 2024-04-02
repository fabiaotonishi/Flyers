using Flyers.Core.Entities;
using Flyers.Web.Models;

namespace Flyers.Web.Areas.App.ViewModels
{
    public class MembroViewModel
    {
        public string Nome { get; set; }
        public string Perfil { get; set; }
        public Conta Conta { get; set; }
        public ArquivoEntity Imagem { get; set; }

        public MembroViewModel()
        {
            Conta = new Conta();
            Imagem = new ArquivoEntity();
        }
    }
}
