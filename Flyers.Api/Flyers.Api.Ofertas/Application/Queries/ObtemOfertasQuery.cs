using Flyers.Api.Application;
using Flyers.Api.Ofertas.Models;
using MediatR;
using System.Collections.Generic;

namespace Flyers.Api.Ofertas.Application.Queries
{
    public class ObtemOfertasQuery : BaseQuery, IRequest<List<Oferta>>
    {        
    }
}
