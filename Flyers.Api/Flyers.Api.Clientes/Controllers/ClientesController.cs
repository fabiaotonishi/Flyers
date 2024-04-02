using Flyers.Api.Application;
using Flyers.Api.Clientes.Application.Commands;
using Flyers.Api.Clientes.Application.Queries;
using Flyers.Api.Clientes.Models;
using Flyers.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Api.Clientes.Controllers
{
    [Route("api/clientes")]
    public class ClientesController : BaseController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClientesController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("{id}")]
        [ActionName(nameof(ObtemClientePorIdAsync))]
        public async Task<ActionResult> ObtemClientePorIdAsync(int id)
        {
            var consulta = new ObtemClientePorIdQuery(id);
            var resposta = await _mediatorHandler.EnviaConsultaAsync(consulta);
            return ApiResposta(resposta);
        }

        [HttpPost]
        public async Task<IActionResult> InsereClienteAsync([FromBody]Cliente cliente)
        {
            var comando = new SalvaClienteCommand(
                0,
                cliente.Nome,
                cliente.Email,
                cliente.Telefone);
            var resposta = await _mediatorHandler.EnviaComandoAsync(comando);
            return ApiResposta(resposta);
        }

        [HttpPut]
        public async Task<IActionResult> AlteraClienteAsync([FromBody] Cliente cliente)
        {
            var comando = new SalvaClienteCommand(
                cliente.Id,
                cliente.Nome,
                cliente.Email,
                cliente.Telefone);
            var resposta = await _mediatorHandler.EnviaComandoAsync(comando);
            return ApiResposta(resposta);
            //var consulta = new ObtemClientePorIdQuery(cliente.Id);
            //return RedirectToAction(nameof(ObtemClientePorIdAsync), new { id = consulta.Id });
        }
    }
}
