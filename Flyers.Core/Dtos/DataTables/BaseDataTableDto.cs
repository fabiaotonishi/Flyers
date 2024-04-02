using System;
using System.Collections.Generic;

namespace Flyers.Core.Dtos.DataTables
{
    public abstract class BaseDataTableDto<T> where T : class
    {
        public IEnumerable<T> Tabela { get; set; }
        public int TabelaTotal { get; set; }
        public int PaginaAtual { get; set; }
        public int PaginaExibe { get; set; }
        public int TotalDePaginas()
        {
           return (int)Math.Ceiling(decimal.Divide(TabelaTotal, PaginaExibe));
        }
    }
}
