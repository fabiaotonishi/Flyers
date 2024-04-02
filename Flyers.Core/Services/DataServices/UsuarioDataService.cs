using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataRepositories;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Core.Services.DataServices
{
    public class UsuarioDataService : BaseDataService<UsuarioEntity>, IUsuarioDataService
    {
        public UsuarioDataService(IDataRepository dataRepository) 
            : base(dataRepository)
        {
        }

        public override async Task<bool> ExcluiAsync(int id)
        {
            //Exclusão com relacionamentos
            try
            {
                var arquivo = await Task.Run(
                        () => _baseDataRepository
                        .Repositorio<ArquivoEntity>()
                        .Consulta()
                        .FirstOrDefault(e => e.Entidade == id && e.Pasta == PastaValue.Usuario));
                if (arquivo != null)
                {
                    _baseDataRepository
                        .Repositorio<ArquivoEntity>()
                        .Remove(arquivo);
                    await _baseDataRepository
                        .Repositorio<ArquivoEntity>()
                        .SalvaAsync();
                }
                await base.ExcluiAsync(id);
                return _baseDataRepository.ConfirmaOuReverteTodos();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public async Task<UsuarioEntity> ObtemPorEmailSenhaAsync(string email, string senha)
        {
            try
            {
                return await Task.Run(() => _baseDataRepository
                    .Repositorio<UsuarioEntity>()
                    .Consulta()
                    .FirstOrDefault(e => e.Email == email && e.Senha == senha));
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}
