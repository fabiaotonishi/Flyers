using Flyers.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Flyers.Core.Dtos.DataTables
{
    public class OfertaProdutoDataTableDto : BaseDataTableDto<OfertaProdutoEntity>
    {
        public IEnumerable<IGrouping<CategoriaEntity, OfertaProdutoEntity>> AgrupaProdutosPorCategorias()
        {
            return Tabela.GroupBy(e => e.Produto.Categoria).Distinct();
        }

        public IEnumerable<CategoriaEntity> ListaCategorias()
        {
            return Tabela.Select(x => x.Produto).Select(x => x.Categoria).Distinct();
        }
    }
}
