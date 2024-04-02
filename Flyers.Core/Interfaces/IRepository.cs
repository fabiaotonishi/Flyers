using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Flyers.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Consulta();
        IQueryable<T> Consulta(params Expression<Func<T, object>>[] includes);
        void Adiciona(T entidade);
        void Atualiza(T entidade);
        void Remove(T entidade);
        T Seleciona(int? id);
        Task<T> SelecionaAsync(int? id);
        int Salva();
        Task<int> SalvaAsync();
        void Dispose();
    }
}
