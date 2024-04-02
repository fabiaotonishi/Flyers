using Flyers.Api.Application;
using Flyers.Api.Clientes.Application.Validators;
using MediatR;
using System;

namespace Flyers.Api.Clientes.Application.Commands
{
    public class SalvaClienteCommand : BaseCommand
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        public SalvaClienteCommand(int id, string nome, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        /// <summary>
        /// Validacao pelo AbstractValidator
        /// </summary>
        public override bool Valido()
        {
            ValidationResult = new SalvaClienteValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
