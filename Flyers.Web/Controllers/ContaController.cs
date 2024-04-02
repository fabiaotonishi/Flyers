using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Extensions;
using Flyers.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;

namespace Flyers.Web.Controllers
{
    public class ContaController : BaseController
    {
        private readonly IUsuarioDataService _usuarioDataServico;

        public ContaController(
            ILogger<BaseController> logger, 
            IHttpContextAccessor httpContextAccessor, 
            IDominioDataService dominioDataService, 
            IArquivoDataService arquivoDataService,
            IUsuarioDataService usuarioDataService) 
            : base(logger, httpContextAccessor, dominioDataService, arquivoDataService)
        {
            _usuarioDataServico = usuarioDataService;
        }

        public IActionResult Index(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Finaliza", "Conta");
            }
            ViewBag.Url = returnUrl;
            return View(new Login());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _AutenticaAsync(Login login, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = await _usuarioDataServico.ObtemPorEmailSenhaAsync(login.Email, login.Senha.ToMd5());
                    if (usuario == null)
                    {
                        ModelState.AddModelError("Senha", "E-mail ou senha inválidos");
                        return PartialView(login);
                    }
                    //crendencial
                    var credencial = new List<Claim>
                {
                    new Claim("Chave", usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Perfil.ToString())
                };
                    var credencialCookie = new ClaimsIdentity(
                        credencial, CookieAuthenticationDefaults.AuthenticationScheme);
                    var autenticacaoRegras = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        IsPersistent = login.Conectado,
                        IssuedUtc = DateTime.Now,
                        RedirectUri = @"~/home/"
                    };
                    var credencialUsuario = new ClaimsPrincipal(credencialCookie);
                    await HttpContext.SignInAsync(credencialUsuario, autenticacaoRegras);
                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        returnUrl = Url.Action("Index", "Home", new { area = "App" });
                    }
                    return Ok(new
                    {
                        valido = true,
                        url = returnUrl
                    });
                }
                return PartialView(login);
            }
            catch (Exception erro)
            {
                Debug.WriteLine($"Error: {erro}");
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> FinalizaAsync()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
