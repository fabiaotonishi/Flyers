using Flyers.Core.Entities;
using Flyers.Core.Values;
using System.Threading.Tasks;

namespace Flyers.Core.Interfaces.DataServices
{
    public interface IArquivoDataService : IDataService<ArquivoEntity>
    {
        Task<ArquivoEntity> ObtemImagemAsync(string nome);
        Task<ArquivoEntity> ObtemImagemAsync(int idEntidade, PastaValue pasta);
        Task<bool> ExcluiImagemAsync(int idEntidade, PastaValue pasta);
    }
}
