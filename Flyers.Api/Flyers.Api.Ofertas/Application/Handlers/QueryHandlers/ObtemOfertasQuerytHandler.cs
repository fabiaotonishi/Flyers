using AutoMapper;
using Flyers.Api.Ofertas.Application.Queries;
using Flyers.Api.Ofertas.Models;
using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flyers.Api.Ofertas.Application.Handlers.QueryHandlers
{
    public class ObtemOfertasQuerytHandler : IRequestHandler<ObtemOfertasQuery, List<Oferta>>
    {
        private readonly IOfertaDataService _ofertaDataService;
        private readonly IArquivoDataService _arquivoDataService;
        private readonly IMapper _mapper;

        public ObtemOfertasQuerytHandler(
            IArquivoDataService arquivoDataService,
            IOfertaDataService ofertaDataService,
            IMapper mapper)
        {
            _arquivoDataService = arquivoDataService;
            _ofertaDataService = ofertaDataService;            
            _mapper = mapper;
        }

        public async Task<List<Oferta>> Handle(
            ObtemOfertasQuery request, 
            CancellationToken cancellationToken)
        {
            try
            {
                //busca no repositorio de dados
                var ofertas = await _ofertaDataService
                    .ListaAsync();
                foreach (var oferta in ofertas)
                {
                    oferta.Imagem = await _arquivoDataService
                        .ObtemImagemAsync(oferta.Id, PastaValue.Oferta);
                }
                //mapeamento da resposta
                return _mapper
                    .Map<List<OfertaEntity>, List<Oferta>>(ofertas.ToList());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}
