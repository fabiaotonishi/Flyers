using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using Flyers.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Flyers.Web.Areas.App.Controllers
{
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioDataService _usuarioDataService;
        public UsuariosController(
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
                var usuarios = await _usuarioDataService.ListaAsync();
                if (usuarios.Count() > 0)
                {
                    foreach (var usuario in usuarios)
                    {
                        usuario.Imagem = await BuscaImagemAsync(usuario.Id, PastaValue.Usuario);
                    }
                }
                return View(usuarios);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        public async Task<IActionResult> ExibeAsync(int id)
        {
            try
            {
                var usuario = await _usuarioDataService.ObtemPorIdAsync(id);
                if (usuario == null)
                {
                    usuario = new UsuarioEntity();
                }
                usuario.Imagem = await BuscaImagemAsync(usuario.Id, PastaValue.Usuario);
                return View(usuario);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        public async Task<IActionResult> ObtemAsync(int id)
        {
            try
            {
                var usuario = await _usuarioDataService.ObtemPorIdAsync(id);
                if (usuario == null)
                {
                    usuario = new UsuarioEntity();
                }
                usuario.Imagem = await BuscaImagemAsync(usuario.Id, PastaValue.Usuario);
                return PartialView("_Obtem", usuario);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }            
        }

        [HttpGet]
        public async Task<IActionResult> EditaAsync(int id)
        {
            try
            {
                var usuario = await _usuarioDataService.ObtemPorIdAsync(id);
                return PartialView("_Edita", usuario);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditaAsync(UsuarioEntity usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario.CriptografaDados();
                    ModelState.Clear();
                    var idUsuario = await _usuarioDataService.SalvaAsync(usuario);
                    return Ok(new AppResposta()
                    {
                        Retorno = (idUsuario > 0) ? true : false,
                        Url = Url.Action("Exibe", "Usuarios", new { area = "App", id = idUsuario })
                    });
                    //return Ok(new AppResposta()
                    //{
                    //    Retorno = (await _usuarioDataService.SalvaAsync(usuario) > 0) ? true : false
                    //});
                }
                return PartialView(usuario);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ApagaAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }
                var usuario = await _usuarioDataService.ObtemPorIdAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                return PartialView("_Apaga", usuario);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _ApagaAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }
                return Ok(new AppResposta()
                {
                    Retorno = await _usuarioDataService.ExcluiAsync(id),
                    Carrega = false
                });
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }
    }
}
