using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Api.Clientes.Models
{
    public class Cliente
    {
        //Propriedades
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Pessoa { get; set; }
    }
}
