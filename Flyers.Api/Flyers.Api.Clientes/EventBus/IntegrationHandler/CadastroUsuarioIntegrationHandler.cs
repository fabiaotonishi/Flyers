using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Flyers.Api.EventBus;
using MediatR;

namespace Flyers.Api.Clientes.EventBus.IntegrationHandler
{
    public class CadastroUsuarioIntegrationHandler : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEventBus _eventBus;
        private readonly IMediator _mediator;

        public CadastroUsuarioIntegrationHandler(IServiceProvider serviceProvider, IEventBus eventBus, IMediator mediator)
        {
            _serviceProvider = serviceProvider;
            _eventBus = eventBus;
            _mediator = mediator;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //_eventBus.RespondAsync<UsuarioIntegrationEvent, ValidacaoMessageEvent>(async request =>
            //    await CadastraUsuarioAsync(request));
            return Task.CompletedTask;
        }

        //private async Task<ValidacaoMessageEvent> CadastraUsuarioAsync(UsuarioIntegrationEvent request)
        //{
        //    ValidationResult resposta;
        //    var command = new SalvaClienteCommand(request.Id, request.Nome, request.Email, request.Telefone);
        //    using (var scope = _serviceProvider.CreateScope())
        //    {
        //        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        //        resposta = await mediator.Send(command);
        //    }
        //    return new ValidacaoMessageEvent(resposta.IsValid);
        //}
    }
}
