using Flyers.Api.Clientes.Application.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flyers.Api.Clientes.Application.Handlers.EventHandlers
{
    public class ClienteSalvoEventHandler : INotificationHandler<ClienteSalvoEvent>
    {
        public Task Handle(ClienteSalvoEvent notification, CancellationToken cancellationToken)
        {
            //enviar informacoes de confirmacao
            return Task.CompletedTask;
        }
    }
}
