using AutoMapper;
using FluentValidation.Results;
using Flyers.Api.Application;
using Flyers.Api.Clientes.Application.Commands;
using Flyers.Api.Clientes.Application.Events;
using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataServices;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Flyers.Api.Clientes.Application.Handlers.CommandHandlers
{
    public class SalvaClienteCommandHandler : BaseCommandHandler, IRequestHandler<SalvaClienteCommand, ValidationResult>
    {

        private readonly IClienteDataService _clienteDataService;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;

        public SalvaClienteCommandHandler(
            IClienteDataService clienteDataService,
            IMediatorHandler mediatorHandler,
            IMapper mapper)
        {
            _clienteDataService = clienteDataService;
            _mediatorHandler = mediatorHandler;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Handle(SalvaClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //validacao do comando pelo AbstractValidator
                if (!request.Valido())
                {
                    return request.ValidationResult;
                }
                //validacao das regras de negocio do sistema
                //exemplo verificar o cpf já cadastrado
                //if (true)
                //{
                //    IncluiErro("cpf invalido");
                //    return ValidationResult;
                //}
                var cliente = await _clienteDataService.ObtemPorIdAsync(request.Id);
                if (cliente == null)
                {
                    cliente = new ClienteEntity();
                }
                cliente.Nome = request.Nome;
                cliente.Email = request.Email;
                cliente.Telefone = request.Telefone;
                var salvou = await _clienteDataService.SalvaAsync(cliente);
                if (salvou > 0)
                {
                    //realiza a notificação do evento
                    await _mediatorHandler.PublicaEventoAsync(new ClienteSalvoEvent(
                         cliente.Id,
                         cliente.IdHash,
                         cliente.Nome,
                         cliente.Email,
                         cliente.Telefone));
                }
                return await Task.FromResult(request.ValidationResult);
            }
            catch (Exception erro)
            {
                IncluiErro(erro.Message);
                return ValidationResult;
            } 
        }
    }
}
