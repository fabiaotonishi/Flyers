using Flyers.Core.Entities;
using System.Threading.Tasks;

namespace Flyers.Core.Interfaces.DataServices
{
    public interface IEnderecoDataService : IDataService<EnderecoEntity>
    {
        Task<bool> SalvaEnderecoDominioAsync(EnderecoEntity endereco, int idDominio);
    }
}
