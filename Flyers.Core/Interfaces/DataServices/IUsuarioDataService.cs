using Flyers.Core.Entities;
using System.Threading.Tasks;

namespace Flyers.Core.Interfaces.DataServices
{
    public interface IUsuarioDataService : IDataService<UsuarioEntity>
    {
        Task<UsuarioEntity> ObtemPorEmailSenhaAsync(string email, string senha);
    }
}
