using EasyNetQ;
using Flyers.Api.Autenticacao.Models;
using Flyers.Api.Autenticacao.Services;
using Flyers.Api.Controllers;
using Flyers.Api.EventBus.IntegrationEvents;
using Flyers.Api.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Flyers.Api.Autenticacao.Controllers
{
    [Route("api/autenticacao")]
    public class AutenticacaoController : BaseController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        //private readonly IEventBus _eventBus;
        private IBus _bus;

        public AutenticacaoController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            //IOptions injeta os valores do json
            _appSettings = appSettings.Value;
        }

        [HttpPost("registra-usuario")]
        public async Task<ActionResult> RegistraUsuarioAsync(Conta conta)
        {
            //verifica os dados para registro
            if (!ModelState.IsValid)
            {
                return ApiResposta(ModelState);
            }

            //registra a conta do usuario no Identity
            var usuarioIdentidade = new IdentityUser
            {
                UserName = conta.Nome,
                Email = conta.Email,
                EmailConfirmed = true
            };
            var resultado = await _userManager.CreateAsync(usuarioIdentidade, conta.Senha);

            if (resultado.Succeeded)
            {
                //autenticacao padrao 
                //await _signInManager.CanSignInAsync(usuarioIdentidade);
                //return ApiResposta();

                //autenticacao pelo Identity
                var resposta = await CadastraClienteAsync(conta);

                //gera token para usuario identificado e registrado
                return ApiResposta(await GeraJwtIdentityAsync(conta.Email));
            }
            
            //faz o tratamento dos erros
            foreach (var erro in resultado.Errors)
            {
                IncluiErro(erro.Description);
            }
            return ApiResposta();
        }

        [HttpPost("autentica-usuario")]
        public async Task<ActionResult> AutenticaUsuarioAsync(Login login)
        {
            //verifica os dados do login
            if (!ModelState.IsValid)
            {
                return ApiResposta(ModelState);
            }

            //verifica do usuario do Identity
            var usuarioIdentidade = await _userManager.FindByEmailAsync(login.Email);
            if (usuarioIdentidade != null)
            {
                var resultado = await _signInManager.PasswordSignInAsync(usuarioIdentidade.UserName, login.Senha, false, true);

                if (resultado.Succeeded)
                {
                    //return ApiResposta();
                    //gera o token de autenticao para o usuario do Identity
                    return ApiResposta(await GeraJwtIdentityAsync(usuarioIdentidade.Email));
                }

                //faz o tratamento dos erros
                if (resultado.IsLockedOut)
                {
                    IncluiErro("Usuário temporariamente bloqueado por tentativas inválidas");
                    return ApiResposta();
                }
            }            

            IncluiErro("Usuário ou Senha incorretos");
            return ApiResposta();
        }

        /// <summary>
        /// Gera o token JWT para a indentidade do usuário
        /// </summary>        
        private async Task<UsuarioToken> GeraJwtIdentityAsync(string email)
        {
            //Identity
            var usuarioIdentidade = await _userManager.FindByEmailAsync(email);
            var usuarioPermissoes = await _userManager.GetRolesAsync(usuarioIdentidade);
            //Conta do usuario padrao
            var usuarioConta = new UsuarioConta
            {
                Id = usuarioIdentidade.Id,
                Nome = usuarioIdentidade.UserName,
                Email = usuarioIdentidade.Email,
            };
            foreach (var role in usuarioPermissoes)
            {
                usuarioConta.Permissoes.Add(role);
            }
            //Obtem a credencial do usuario para o token
            var credenciaisJwt = TokenService.ObtemCredenciaisJwt(usuarioConta);
            //Obtem o token de autenticacao do usuario
            var tokenAcesso = TokenService.ObtemTokenAcesso(
                _appSettings.Chave,
                _appSettings.Emissor,
                _appSettings.ValidoEm,
                credenciaisJwt,
                _appSettings.ExpiracaoHoras);

            return new UsuarioToken
            {
                Token = tokenAcesso,
                Expiracao = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UsuarioConta = usuarioConta
            };
        }

        /// <summary>
        /// Envia a conta de registro do usuario para a fila de mensagem para ser registrado pela API de cliente
        /// </summary>
        private async Task<MensagemIntegrationEvent> CadastraClienteAsync(Conta conta)
        {
            var usuarioIdentidade = await _userManager.FindByEmailAsync(conta.Email);
            var usuarioCadastrado = new UsuarioCadastradoIntegrationEvent(
                0,
                Guid.Parse(usuarioIdentidade.Id),
                conta.Nome,
                conta.Email,
                conta.Telefone);
            _bus = RabbitHutch.CreateBus("localhost:5672");
            return await _bus.Rpc.RequestAsync<UsuarioCadastradoIntegrationEvent, MensagemIntegrationEvent>(usuarioCadastrado);

        }
    }
}
