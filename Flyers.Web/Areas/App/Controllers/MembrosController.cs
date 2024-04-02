using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using Flyers.Web.Areas.App.ViewModels;
using Flyers.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Flyers.Web.Areas.App.Controllers
{
    public class MembrosController : BaseController
    {
        private readonly IUsuarioDataService _usuarioDataService;

        public MembrosController(
            ILogger<BaseController> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IDominioDataService dominioDataService, 
            IArquivoDataService arquivoDataService,
            IUsuarioDataService usuarioDataService) 
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
            _usuarioDataService = usuarioDataService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var usuario = await _usuarioDataService.ObtemPorIdAsync(contaChave);
                if (usuario == null)
                {
                    return RedirectToAction("Finaliza", "Conta", new { area = "Default" });
                }
                var membro = new MembroViewModel();
                membro.Nome = contaAtual;
                membro.Perfil = contaNivel;
                membro.Conta.Nome = usuario.Nome;
                membro.Conta.Telefone = usuario.Telefone;
                membro.Imagem = await BuscaImagemAsync(usuario.Id, PastaValue.Usuario);
                return View(membro);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditaAsync(Conta conta)
        {
            try
            {
                var usuario = await _usuarioDataService.ObtemPorIdAsync(contaChave);
                if (usuario == null)
                {
                    return RedirectToAction("Finaliza", "Conta", new { area = "Default" });
                }
                if (ModelState.IsValid)
                {
                    usuario.Nome = conta.Nome;
                    usuario.Telefone = conta.Telefone;
                    usuario.Senha = conta.Senha;
                    usuario.CriptografaDados();
                    ModelState.Clear();
                    return Ok(new AppResposta()
                    {
                        Retorno = (await _usuarioDataService.SalvaAsync(usuario) > 0) ? true : false
                    });
                }
                return PartialView(usuario);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }
    }
}
