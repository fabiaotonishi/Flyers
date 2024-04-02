using Flyers.Api.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Api.Clientes.Application.Events
{
    public class ClienteSalvoEvent : BaseEvent
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        public ClienteSalvoEvent(int id, Guid idHash, string nome, string email, string telefone)
        {
            Id = id;
            IdHash = idHash;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}
