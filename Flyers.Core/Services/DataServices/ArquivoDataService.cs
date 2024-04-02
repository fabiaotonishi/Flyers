using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataRepositories;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Core.Services.DataServices
{
    public class ArquivoDataService : BaseDataService<ArquivoEntity>, IArquivoDataService
    {
        public ArquivoDataService(IDataRepository dataRepository) : base(dataRepository)
        {
        }

        public async Task<ArquivoEntity> ObtemImagemAsync(string nome)
        {
            try
            {
                return await Task.Run(() => _baseDataRepository
                    .Repositorio<ArquivoEntity>()
                    .Consulta()
                    .Where(e => e.Tipo.Contains("image"))
                    .FirstOrDefault(e => e.Nome == nome));
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public async Task<ArquivoEntity> ObtemImagemAsync(int idEntidade, PastaValue pasta)
        {
            try
            {
                return await Task.Run(() => _baseDataRepository
                    .Repositorio<ArquivoEntity>()
                    .Consulta(e => e.Dominio)
                    .Where(e => e.Tipo.Contains("image"))
                    .FirstOrDefault(e => e.Entidade == idEntidade && e.Pasta == pasta));
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public async Task<bool> ExcluiImagemAsync(int idEntidade, PastaValue pasta)
        {
            try
            {
                var entidade = await ObtemImagemAsync(idEntidade, pasta);

                _baseDataRepository
                    .Repositorio<ArquivoEntity>()
                    .Remove(entidade);

                return (await _baseDataRepository
                    .Repositorio<ArquivoEntity>()
                    .SalvaAsync() > 0) ? true : false;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}

