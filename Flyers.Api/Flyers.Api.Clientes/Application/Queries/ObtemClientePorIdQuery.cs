using Flyers.Api.Application;
using Flyers.Api.Clientes.Models;
using MediatR;

namespace Flyers.Api.Clientes.Application.Queries
{
    public class ObtemClientePorIdQuery : BaseQuery, IRequest<Cliente>
    {
        public int Id { get; private set; }

        public ObtemClientePorIdQuery(int id)
        {
            Id = id;
        }
    }
}
