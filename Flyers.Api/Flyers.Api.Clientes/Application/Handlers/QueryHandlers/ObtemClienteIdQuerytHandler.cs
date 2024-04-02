using AutoMapper;
using Flyers.Api.Clientes.Application.Queries;
using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataServices;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Flyers.Api.Clientes.Models;

namespace Flyers.Api.Clientes.Application.Handlers.QueryHandlers
{
    public class ObtemClienteIdQuerytHandler : IRequestHandler<ObtemClientePorIdQuery, Cliente>
    {
        private readonly IClienteDataService _clienteDataService;
        private readonly IMapper _mapper;

        public ObtemClienteIdQuerytHandler(
            IClienteDataService clienteDataService,
            IMapper mapper)
        {
            _clienteDataService = clienteDataService;
            _mapper = mapper;
        }

        public async Task<Cliente> Handle(ObtemClientePorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cliente = await _clienteDataService.ObtemPorIdAsync(request.Id);
                //mapeamento da resposta
                return _mapper.Map<ClienteEntity, Cliente>(cliente);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}
