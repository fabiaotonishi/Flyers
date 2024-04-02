using Flyers.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flyers.Core.Interfaces.DataServices
{
    public interface IProdutoDataService : IDataService<ProdutoEntity>
    {
        Task<IEnumerable<ProdutoEntity>> ListaPorCategoriaAsync(int idCategoria);
        Task<IEnumerable<ProdutoEntity>> ListaPorCategoriaAsync(int idCategoria, string ordem);
        Task<IEnumerable<ProdutoEntity>> ListaPorDestaquesAsync(int index, int exibe, string ordem);
    }
}
