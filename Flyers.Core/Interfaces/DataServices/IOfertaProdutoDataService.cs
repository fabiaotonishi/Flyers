using Flyers.Core.Dtos.DataTables;
using Flyers.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flyers.Core.Interfaces.DataServices
{
    public interface IOfertaProdutoDataService : IDataService<OfertaProdutoEntity>
    {
        Task<OfertaProdutoEntity> ObtemPorOfertaProdutoAsync(int idOferta, int idProduto);
        Task<IEnumerable<OfertaProdutoEntity>> ListaPorOfertaAsync(int idOferta);
        Task<IEnumerable<OfertaProdutoEntity>> ListaPorOfertaProdutoCategoriaAsync(int idOferta, int idCategoria);
        Task<OfertaProdutoDataTableDto> ListaPorFiltroAsync(int idOferta, string busca, int index, int exibe, string ordem);
        Task<OfertaProdutoDataTableDto> ListaPorFiltroAsync(int idOferta, int idCategoria, string busca, int index, int exibe, string ordem);
        Task<bool> SalvaTodosAsync(List<OfertaProdutoEntity> ofertaProdutos);

    }
}
