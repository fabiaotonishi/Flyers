using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyers.Api.Application
{
    public abstract class BaseCommandHandler
    {
        protected ValidationResult ValidationResult;

        protected BaseCommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void IncluiErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }
    }
}
