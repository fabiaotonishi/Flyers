using Flyers.Api.Application;
using Flyers.Api.Ofertas.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Flyers.Api.Ofertas.Application.Queries
{
    public class ObtemOfertasPorPeriodoQuery : BaseQuery, IRequest<List<Oferta>>
    {
        public DateTime Inicio { get; private set; }
        public DateTime Termino { get; private set; }

        public ObtemOfertasPorPeriodoQuery(DateTime inicio, DateTime terminio)
        {
            Inicio = inicio;
            Termino = terminio;
        }
    }
}
