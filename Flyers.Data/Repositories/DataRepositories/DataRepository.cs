using Flyers.Core.Interfaces;
using Flyers.Core.Interfaces.DataRepositories;
using Flyers.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flyers.Data.Repositories.DataRepositories
{
    /// <summary>
    /// Implementacao base da interface IDataRepository
    /// </summary>
    public class DataRepository : IDataRepository
    {
        private readonly DadosDbContext _dadosContext;
        IDbContextTransaction _dadosContextTransaction;
        Dictionary<Type, object> repositorios = new Dictionary<Type, object>();
        bool retorno;

        //Metodos
        public DataRepository(DadosDbContext dadosContext)
        {
            _dadosContext = dadosContext;
            retorno = false;
        }

        /// <summary>
        ///  Método que instancia um repositório da entidade dinamicamente
        /// </summary>
        /// <typeparam name="T">Entidade</typeparam>        
        /// <returns>Retorna o repositorio de dados da entidade</returns>
        public virtual IRepository<T> Repositorio<T>() where T : class
        {
            //Verifica se a entidade é um repositorio de dados
            if (repositorios.Keys.Contains(typeof(T)) == true)
            {
                return repositorios[typeof(T)] as IRepository<T>;
            }
            //Instancia o repositorio de dados da entidade
            IRepository<T> repositorio = new Repository<T>(_dadosContext);
            repositorios.Add(typeof(T), repositorio);
            return repositorio;
        }

        /// <summary>
        /// Método que salva todos os repositorios do contexto por Commit/Rollback
        /// </summary>
        public virtual bool ConfirmaOuReverteTodos()
        {
            using (_dadosContextTransaction = _dadosContext.Database.BeginTransaction())
            {
                try
                {
                    _dadosContextTransaction.Commit();
                    retorno = true;
                }
                catch (Exception erro)
                {
                    _dadosContextTransaction.Rollback();
                    throw new Exception(erro.Message);
                }
                finally
                {
                    _dadosContext.Dispose();
                    _dadosContextTransaction.Dispose();
                }
                return retorno;
            }
        }

        public virtual void Dispose()
        {
            _dadosContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
