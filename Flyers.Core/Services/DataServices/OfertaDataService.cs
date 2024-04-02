using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataRepositories;
using Flyers.Core.Interfaces.DataServices;
using Flyers.Core.Values;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Flyers.Core.Services.DataServices
{
    public class OfertaDataService : BaseDataService<OfertaEntity>, IOfertaDataService
    {
        public OfertaDataService(IDataRepository dataRepository) : base(dataRepository)
        {
        }

        public override async Task<bool> ExcluiAsync(int id)
        {
            //Exclusão com relacionamentos
            try
            {
                //arquivo
                var arquivo = await Task.Run(
                        () => _baseDataRepository
                        .Repositorio<ArquivoEntity>()
                        .Consulta()
                        .FirstOrDefault(e => e.Entidade == id && e.Pasta == PastaValue.Oferta));
                if (arquivo != null)
                {
                    _baseDataRepository
                        .Repositorio<ArquivoEntity>()
                        .Remove(arquivo);
                    await _baseDataRepository
                        .Repositorio<ArquivoEntity>()
                        .SalvaAsync();
                }
                //promocoes produtos
                var ofertaProdutos = await Task.Run(
                        () => _baseDataRepository
                        .Repositorio<OfertaProdutoEntity>()
                        .Consulta()
                        .Where(e => e.IdOferta == id));
                if (ofertaProdutos.Count() > 0)
                {
                    foreach (var ofertaProduto in ofertaProdutos)
                    {
                        _baseDataRepository
                            .Repositorio<OfertaProdutoEntity>()
                            .Remove(ofertaProduto);
                    }
                    await _baseDataRepository
                        .Repositorio<OfertaProdutoEntity>()
                        .SalvaAsync();
                }
                //oferta
                await base.ExcluiAsync(id);
                return _baseDataRepository.ConfirmaOuReverteTodos();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public async Task<IEnumerable<OfertaEntity>> ListaPorDatasAsync(DateTime inicio, DateTime termino)
        {
            try
            {
                var consulta = _baseDataRepository
                    .Repositorio<OfertaEntity>()
                    .Consulta(e => e.OfertaProdutos)
                    .Where(e => !e.Inativo && e.Inicio.Date >= inicio && e.Termino.Date <= termino);

                return await Task.FromResult(consulta.ToList());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public async Task<IEnumerable<OfertaEntity>> ListaPorDataTerminoAsync(DateTime termino, int index, int exibe, string ordem)
        {
            try
            {
                var consulta = _baseDataRepository
                    .Repositorio<OfertaEntity>()
                    .Consulta(e => e.OfertaProdutos)
                    .Where(e => !e.Inativo && e.Termino.Date <= termino);

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

        public async Task<OfertaEntity> ObtemPorIdComProdutosAsync(int id)
        {
            try
            {
                var oferta = _baseDataRepository
                    .Repositorio<OfertaEntity>()
                    .Consulta()
                    .Include(e => e.OfertaProdutos)
                    .ThenInclude(e => e.Produto)
                    .ThenInclude(e => e.Categoria)
                    .FirstOrDefault(e => e.Id == id);

                return await Task.FromResult(oferta);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}
