using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyers.Api.Application
{
    public interface IMediatorHandler
    {
        Task PublicaEventoAsync<T>(T evento) where T : BaseEvent;
        Task<ValidationResult> EnviaComandoAsync<T>(T comando) where T : BaseCommand;
        Task<T> EnviaConsultaAsync<T>(IRequest<T> consulta) where T : class;

    }
}
