using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyers.Api.Application
{
    public class Mensagem
    {
        public Guid IdHash { get; protected set; }
        public DateTime Criado { get; protected set; }

        protected Mensagem()
        {
            IdHash = Guid.NewGuid();
            Criado = DateTime.UtcNow;
        }
    }
}
