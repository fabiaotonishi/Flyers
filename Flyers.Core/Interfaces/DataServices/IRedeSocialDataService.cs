using Flyers.Core.Entities;
using Flyers.Core.Values;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flyers.Core.Interfaces.DataServices
{
    public interface IRedeSocialDataService : IDataService<RedeSocialEntity>
    {
        Task<IEnumerable<RedeSocialEntity>> ListaAsync(int idDominio);
        Task<RedeSocialEntity> ObtemPorDominioCanalAsync(int idDominio, CanalValue canal);
    }
}
