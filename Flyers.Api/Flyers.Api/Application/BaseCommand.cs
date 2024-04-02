using FluentValidation.Results;
using MediatR;
using System;

namespace Flyers.Api.Application
{
    public abstract class BaseCommand : Mensagem, IRequest<ValidationResult>
    {
        public ValidationResult ValidationResult { get; protected set; }

        public virtual bool Valido()
        {
            throw new NotImplementedException();
        }
    }
}
