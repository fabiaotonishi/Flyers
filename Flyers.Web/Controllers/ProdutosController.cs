using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Web.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoDataService _produtoDataService;

        public ProdutosController(
            ILogger<ProdutosController> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IDominioDataService dominioDataService, 
            IArquivoDataService arquivoDataService,
            IProdutoDataService produtoDataService) 
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
            _produtoDataService = produtoDataService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var produtos = await _produtoDataService.ListaAsync(e => e.Categoria);
            if (produtos.Count() > 0)
            {
                foreach (var produto in produtos)
                {
                    produto.Imagem = await _arquivoDataService.ObtemImagemAsync(
                        produto.Id,
                        PastaValue.Produto);
                }
            }
            return View(produtos);
        }

        public async Task<IActionResult> DetalhesAsync(int id)
        {
            var produto = await _produtoDataService.ObtemPorIdAsync(id);
            if (produto != null)
            {
                produto.Imagem = await _arquivoDataService.ObtemImagemAsync(
                        produto.Id,
                        PastaValue.Produto);
            }
            return PartialView("_Detalhes", produto);
        }

        public async Task<IActionResult> DestaqueAsync(int exibe = 8)
        {
            var produtos = await _produtoDataService.ListaPorDestaquesAsync(
                0,
                exibe, 
                "Nome asc");
            if (produtos.Count() > 0)
            {
                foreach (var produto in produtos)
                {
                    produto.Imagem = await _arquivoDataService.ObtemImagemAsync(
                        produto.Id,
                        PastaValue.Produto);
                }
            }
            return PartialView("_Destaque", produtos);
        }

        public async Task<IActionResult> ListagemAsync(int categoria)
        {
            if (categoria == 0)
            {
                NotFound();
            }
            var produtos = await _produtoDataService.ListaPorCategoriaAsync(
                    categoria,
                    "Nome asc");
            if (produtos.Count() > 0)
            {
                foreach (var produto in produtos)
                {
                    produto.Imagem = await _arquivoDataService.ObtemImagemAsync(
                        produto.Id,
                        PastaValue.Produto);
                }
            }
            return PartialView("_Listagem", produtos);
        }
    }
}
