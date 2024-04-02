using Flyers.Core.Interfaces;
using Flyers.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Flyers.Data.Repositories
{
    /// <summary>
    /// Implementacao base da interface IRepository
    /// </summary>
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly DadosDbContext _dadosContext;

        //Metodos     
        public Repository(DadosDbContext dadosContext)
        {
            _dadosContext = dadosContext;
        }

        /// <summary>
        /// Método que adiciona a entidade no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade</param>
        public virtual void Adiciona(T entidade)
        {
            _dadosContext
                .Set<T>()
                .Add(entidade);
        }

        /// <summary>
        /// Método que remove a entidade no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade</param>
        public virtual void Remove(T entidade)
        {
            _dadosContext
                .Set<T>()
                .Remove(entidade);
        }

        /// <summary>
        /// Método que atualiza a entidade no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade</param>
        public virtual void Atualiza(T entidade)
        {
            _dadosContext.Entry(entidade).State = EntityState.Modified;
            _dadosContext
                .Set<T>()
                .Update(entidade);
        }

        /// <summary>
        /// Método que consulta as entidades no banco de dados
        /// </summary>
        /// <param name="entidade">Entidade</param>
        /// <returns>Retorna a lista de entidades</returns>
        public virtual IQueryable<T> Consulta()
        {
            return _dadosContext.Set<T>();
        }

        public virtual IQueryable<T> Consulta(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dadosContext.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.AsNoTracking();
        }

        /// <summary>
        /// Método que seleciona uma entidade no banco de dados
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna a entidade</returns>
        public virtual T Seleciona(int? id)
        {
            return _dadosContext
                .Set<T>()
                .Find(id);
        }

        /// <summary>
        /// Método assincrono que seleciona uma entidade no banco de dados
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Retorna a entidade</returns>
        public virtual async Task<T> SelecionaAsync(int? id)
        {
            return await _dadosContext
                .Set<T>()
                .FindAsync(id);
        }

        /// <summary>
        /// Método que salva a entidade no banco de dados
        /// </summary>
        /// <returns>Retorna o identificador da entidade</returns>
        public virtual int Salva()
        {
            return _dadosContext.SaveChanges();
        }

        /// <summary>
        /// Método assincrono que salva a entidade no banco de dados
        /// </summary>
        /// <returns>Retorna o identificador da entidade</returns>
        public virtual async Task<int> SalvaAsync()
        {
            return await _dadosContext.SaveChangesAsync();
        }

        /// <summary>
        /// Método para despejo de memória
        /// </summary>
        public virtual void Dispose()
        {
            _dadosContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
