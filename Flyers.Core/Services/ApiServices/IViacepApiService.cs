using Flyers.Core.Dtos.Viacep;
using Refit;
using System.Threading.Tasks;

namespace Flyers.Core.Services.ApiServices
{
    public interface IViacepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<CepViacepDto>> GetCepAsync(string cep);
    }
}
