using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Flyers.Core.Interfaces.DataServices
{
    public interface IDataService<T> where T : IEntity
    {
        Task<IEnumerable<T>> ListaAsync();
        Task<IEnumerable<T>> ListaAsync(params Expression<Func<T, object>>[] includes);
        Task<T> ObtemPorIdAsync(int id);
        Task<int> SalvaAsync(T entidade);
        Task<bool> ExcluiAsync(int id);
        Task<bool> ExisteAsync(int id);
        Task AtivaOuInativaAsync(int id);
    }
}
