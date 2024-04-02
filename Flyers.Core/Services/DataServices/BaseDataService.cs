using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataRepositories;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Flyers.Core.Services.DataServices
{
    /// <summary>
    /// Implementacao da interface IDataService
    /// </summary>
    public abstract class BaseDataService<T> : IDisposable, IDataService<T> where T : BaseEntity
    {
        //Atributos
        protected readonly IDataRepository _baseDataRepository;

        //Metodos
        public BaseDataService(IDataRepository dataRepository)
        {
            this._baseDataRepository = dataRepository;
        }

        /// <summary>
        /// Método de listagem das entidades do repositorio de dados
        /// </summary>
        /// <returns>Retorna uma lista de entidades do repositorio de dados</returns>
        public virtual async Task<IEnumerable<T>> ListaAsync()
        {
            try
            {
                return await Task.Run(() => _baseDataRepository
                    .Repositorio<T>()
                    .Consulta()
                    .ToList());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        /// <summary>
        /// Método de listagem das entidades do repositorio de dados
        /// </summary>
        /// <param name="includes">inclui os registros interligados e => e.entidade </param>
        /// <returns>Retorna uma lista de entidades do repositorio de dados</returns>
        public async Task<IEnumerable<T>> ListaAsync(params Expression<Func<T, object>>[] includes)
        {
            try
            {
                return await Task.Run(() => _baseDataRepository
                    .Repositorio<T>()
                    .Consulta(includes)
                    .ToList());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        /// <summary>
        /// Método assincrono que obtem a entidade do repositorio de dados
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Retorna a entidade a partir do seu Id</returns>
        public virtual async Task<T> ObtemPorIdAsync(int id)
        {
            try
            {
                return await Task.Run(() => _baseDataRepository
                    .Repositorio<T>()
                    .SelecionaAsync(id));
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        /// <summary>
        /// Método assincrono de inclsão da entidade do repositorio de dados
        /// </summary>
        /// <param name="entidade">T</param>
        /// <returns>Retorna o Id da entidade salva</returns>
        public virtual async Task<int> SalvaAsync(T entidade)
        {
            try
            {
                if (entidade.Id > 0)
                {
                    _baseDataRepository
                    .Repositorio<T>()
                    .Atualiza(entidade);
                }
                else
                {
                    _baseDataRepository
                    .Repositorio<T>()
                    .Adiciona(entidade);
                }
                await _baseDataRepository
                    .Repositorio<T>()
                    .SalvaAsync();

                return entidade.Id;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        /// <summary>
        /// Método assincrono de exclusão da entidade do repositorio de dados
        /// </summary>
        /// <param name="entidade">T</param>
        /// <returns>Retorna verdadeiro ou falso para operação de exclusão</returns>
        public virtual async Task<bool> ExcluiAsync(int id)
        {
            try
            {
                var entidade = await ObtemPorIdAsync(id);
                if (entidade != null)
                {
                    _baseDataRepository
                    .Repositorio<T>()
                    .Remove(entidade);
                }

                return (await _baseDataRepository
                    .Repositorio<T>()
                    .SalvaAsync() > 0) ? true : false;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        /// <summary>
        /// Metodo assincrono que verifica se existe uma entidade com o id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Retorna verdadeiro ou falso</returns>
        public virtual async Task<bool> ExisteAsync(int id)
        {
            try
            {
                var entidade = await _baseDataRepository
                    .Repositorio<T>()
                    .SelecionaAsync(id);
                return entidade.Equals(null) ? true : false;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        /// <summary>
        /// Metodo assincrono que ativa ou inativa uma entidade 
        /// </summary>
        /// <param name="id">Id</param>        
        public virtual async Task AtivaOuInativaAsync(int id)
        {
            try
            {
                var entidade = _baseDataRepository
                    .Repositorio<T>()
                    .Seleciona(id);
                entidade.Inativo = !entidade.Inativo;
                await _baseDataRepository.Repositorio<T>().SalvaAsync();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        /// <summary>
        /// Método para despejo de memória
        /// </summary>
        public virtual void Dispose()
        {
            try
            {
                _baseDataRepository.Dispose();
                GC.SuppressFinalize(this);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }


        protected internal async Task<ArquivoEntity> BuscaArquivoAsync(int idEntidade, PastaValue pasta)
        {
            //arquivo
            return await Task.Run(
                () => _baseDataRepository
                .Repositorio<ArquivoEntity>()
                .Consulta()
                .FirstOrDefault(e => e.Entidade == idEntidade && e.Pasta == pasta));
        }
    }
}
