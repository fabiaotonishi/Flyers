using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataRepositories;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flyers.Core.Services.DataServices
{
    public class RedeSocialDataService : BaseDataService<RedeSocialEntity>, IRedeSocialDataService
    {
        public RedeSocialDataService(IDataRepository dataRepository) 
            : base(dataRepository)
        {
        }

        public async Task<IEnumerable<RedeSocialEntity>> ListaAsync(int idDominio)
        {
            try
            {                
                return await Task.Run(() => _baseDataRepository
                    .Repositorio<RedeSocialEntity>()
                    .Consulta()
                    .Where(e => !e.Inativo && e.IdDominio == idDominio));
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public async Task<RedeSocialEntity> ObtemPorDominioCanalAsync(int idDominio, CanalValue canal)
        {
            try
            {
                return await Task.Run(() => _baseDataRepository
                    .Repositorio<RedeSocialEntity>()
                    .Consulta()
                    .FirstOrDefault(e => e.IdDominio == idDominio && e.Canal == canal));
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}
