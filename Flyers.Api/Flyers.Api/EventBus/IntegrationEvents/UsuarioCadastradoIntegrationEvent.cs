using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyers.Api.EventBus.IntegrationEvents
{
    public class UsuarioCadastradoIntegrationEvent : BaseIntegrationEvent
    {
        public int Id { get; private set; }        
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public int Perfil { get; private set; }

        public UsuarioCadastradoIntegrationEvent(
            int id,
            string nome,
            string email,
            string telefone,
            int perfil)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Perfil = perfil;
        }

        public UsuarioCadastradoIntegrationEvent(
           int id,
           Guid idHash,
           string nome,
           string email,
           string telefone)
        {
            Id = id;
            IdHash = idHash;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}
