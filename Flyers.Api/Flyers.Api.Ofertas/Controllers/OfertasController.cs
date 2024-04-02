using Flyers.Api.Application;
using Flyers.Api.Controllers;
using Flyers.Api.Ofertas.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Flyers.Api.Ofertas.Controllers
{
    [Route("api/ofertas")]
    public class OfertasController : BaseController
    {
        private readonly IMediatorHandler _mediatorHandler;
        public OfertasController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("erro")]
        public ActionResult Erro()
        {
            //Teste do tratamento de erros
            IncluiErro("Teste erro");
            return ApiResposta();
        }

        [HttpGet("todos")]
        public async Task<ActionResult> ObtemOfertasTodosAsync()
        {
            var consulta = new ObtemOfertasQuery();
            var resposta = await _mediatorHandler.EnviaConsultaAsync(consulta);
            return ApiResposta(resposta);
        }

        [HttpGet("periodo/{inicio}/{termino}")]
        public async Task<ActionResult> ObtemOfertasPorPeridodoAsync(DateTime inicio, DateTime termino)
        {
            var consulta = new ObtemOfertasPorPeriodoQuery(inicio, termino);
            var resposta = await _mediatorHandler.EnviaConsultaAsync(consulta);
            return ApiResposta(resposta);
        }
    }
}
