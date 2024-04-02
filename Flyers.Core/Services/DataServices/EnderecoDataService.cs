using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataRepositories;
using Flyers.Core.Interfaces.DataServices;
using System;
using System.Threading.Tasks;

namespace Flyers.Core.Services.DataServices
{
    public class EnderecoDataService : BaseDataService<EnderecoEntity>, IEnderecoDataService
    {
        public EnderecoDataService(IDataRepository dataRepository) 
            : base(dataRepository)
        {
        }

        public async Task<bool> SalvaEnderecoDominioAsync(EnderecoEntity entidade, int idDominio)
        {
            try
            {
                var dominio = _baseDataRepository
                    .Repositorio<DominioEntity>()
                    .Seleciona(idDominio);
                if (dominio == null)
                {
                    return false;
                }
                dominio.IdEndereco = await base.SalvaAsync(entidade);
                _baseDataRepository
                    .Repositorio<DominioEntity>()
                    .Atualiza(dominio);
                await _baseDataRepository
                        .Repositorio<DominioEntity>()
                        .SalvaAsync();
                return _baseDataRepository.ConfirmaOuReverteTodos();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }   
        }
    }
}
