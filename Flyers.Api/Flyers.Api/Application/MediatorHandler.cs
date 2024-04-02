using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;

namespace Flyers.Api.Application
{
    public class MediatorHandler : IMediatorHandler
    {
        /*
         * implementacao do padrao mediator
         * integracao com o padrao cqrs
         */
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> EnviaComandoAsync<T>(T comando) where T : BaseCommand
        {
            return await _mediator.Send(comando);
        }

        public async Task<T> EnviaConsultaAsync<T>(IRequest<T> consulta) where T : class
        {
            return await _mediator.Send(consulta);
        }

        public async Task PublicaEventoAsync<T>(T evento) where T : BaseEvent
        {
            await _mediator.Publish(evento);
        }

    }
}
