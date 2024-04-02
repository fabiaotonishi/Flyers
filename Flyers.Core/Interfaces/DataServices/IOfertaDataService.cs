using Flyers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flyers.Core.Interfaces.DataServices
{
    public interface IOfertaDataService : IDataService<OfertaEntity>
    {
        Task<OfertaEntity> ObtemPorIdComProdutosAsync(int id);        
        Task<IEnumerable<OfertaEntity>> ListaPorDatasAsync(DateTime inicio, DateTime termino);
        Task<IEnumerable<OfertaEntity>> ListaPorDataTerminoAsync(DateTime termino, int index, int exibe, string ordem);
    }
}
