using FluentValidation;
using Flyers.Api.Clientes.Application.Commands;

namespace Flyers.Api.Clientes.Application.Validators
{
    public class SalvaClienteValidator : AbstractValidator<SalvaClienteCommand>
    {
        public SalvaClienteValidator()
        {
            RuleFor(e => e.IdHash)
                .NotNull()
                .WithMessage("O id é obrigatório");
            RuleFor(e => e.Nome)
                .NotEmpty()
                 .WithMessage("O nome é obrigatório");
            RuleFor(e => e.Email)
                .EmailAddress()
                .WithMessage("O email é obrigatório");
            RuleFor(e => e.Telefone)
                .NotEmpty()
                .WithMessage("O telefone é obrigatório");
        }
    }
}
