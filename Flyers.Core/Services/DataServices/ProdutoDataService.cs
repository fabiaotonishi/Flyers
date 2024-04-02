using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataRepositories;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Flyers.Core.Services.DataServices
{
    public class ProdutoDataService : BaseDataService<ProdutoEntity>, IProdutoDataService
    {
        public ProdutoDataService(IDataRepository dataRepository) 
            : base(dataRepository)
        {
        }

        public async Task<IEnumerable<ProdutoEntity>> ListaPorCategoriaAsync(int idCategoria)
        {
            try
            {
                var consulta = _baseDataRepository
                    .Repositorio<ProdutoEntity>()
                    .Consulta(e => e.Categoria)
                    .Where(e => !e.Inativo && e.IdCategoria == idCategoria);

                return await Task.FromResult(consulta.ToList());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public async Task<IEnumerable<ProdutoEntity>> ListaPorCategoriaAsync(int idCategoria, string ordem)
        {
            try
            {
                var consulta = _baseDataRepository
                    .Repositorio<ProdutoEntity>()
                    .Consulta(e => e.Categoria)
                    .Where(e => !e.Inativo && e.IdCategoria == idCategoria);

                //ordenacao
                if (!string.IsNullOrEmpty(ordem))
                {
                    //ordenacao por string dinamica -System.Linq.Dynamic.Core
                   consulta = consulta.OrderBy($"{ordem}");
                }

                return await Task.FromResult(consulta.ToList());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public async Task<IEnumerable<ProdutoEntity>> ListaPorDestaquesAsync(int index, int exibe, string ordem)
        {
            try
            {
                var consulta = _baseDataRepository
                    .Repositorio<ProdutoEntity>()
                    .Consulta(e => e.Categoria)
                    .Where(e => !e.Inativo && e.Destaque);

                //ordenacao
                if (!string.IsNullOrEmpty(ordem))
                {
                    //ordenacao por string dinamica -System.Linq.Dynamic.Core
                    consulta = consulta.OrderBy($"{ordem}");
                }

                //paginacao
                if (index > 0)
                {
                    consulta = consulta.Skip(index * exibe);
                }
                consulta = consulta.Take(exibe);
                return await Task.FromResult(consulta.ToList());

            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public override async Task<ProdutoEntity> ObtemPorIdAsync(int id)
        {
            try
            {
                return await Task.Run(() => _baseDataRepository
                .Repositorio<ProdutoEntity>()
                .Consulta(e => e.Categoria)
                .FirstOrDefault(e => e.Id == id));
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
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
                        .FirstOrDefault(e => e.Entidade == id && e.Pasta == PastaValue.Produto));
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
    }
}
