﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Api.Ofertas.Models
{
    public class Oferta
    {
        public int Id { get; set; }
        public int IdDominio { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public string Imagem { get; set; }

    }
}
