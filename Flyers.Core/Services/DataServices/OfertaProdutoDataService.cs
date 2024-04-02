using Flyers.Core.Dtos.DataTables;
using Flyers.Core.Entities;
using Flyers.Core.Interfaces.DataRepositories;
using Flyers.Core.Interfaces.DataServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Flyers.Core.Services.DataServices
{
    public class OfertaProdutoDataService : BaseDataService<OfertaProdutoEntity>, IOfertaProdutoDataService
    {
        public OfertaProdutoDataService(IDataRepository dataRepository) : base(dataRepository)
        {
        }

        public async Task<OfertaProdutoEntity> ObtemPorOfertaProdutoAsync(int idOferta, int idProduto)
        {
            try
            {
                return await Task.Run(() => _baseDataRepository
                    .Repositorio<OfertaProdutoEntity>()
                    .Consulta()
                    .FirstOrDefault(e => e.IdOferta == idOferta && e.IdProduto == idProduto));
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public async Task<IEnumerable<OfertaProdutoEntity>> ListaPorOfertaAsync(int idOferta)
        {
            try
            {
                var consulta = _baseDataRepository
                    .Repositorio<OfertaProdutoEntity>()
                    .Consulta()
                    .Include(e => e.Produto)
                    .ThenInclude(e => e.Categoria)
                    .Where(e => !e.Inativo && e.IdOferta == idOferta);

                return await Task.FromResult(consulta.ToList());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public async Task<IEnumerable<OfertaProdutoEntity>> ListaPorOfertaProdutoCategoriaAsync(int idOferta, int idCategoria)
        {
            try
            {
                var consulta = _baseDataRepository
                    .Repositorio<OfertaProdutoEntity>()
                    .Consulta()
                    .Include(e => e.Produto)
                    .ThenInclude(e => e.Categoria)
                    .Where(e => !e.Inativo && e.IdOferta == idOferta && e.Produto.IdCategoria == idCategoria);

                return await Task.FromResult(consulta.ToList());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public async Task<OfertaProdutoDataTableDto> ListaPorFiltroAsync(int idOferta, string busca, int index, int exibe, string ordem)
        {
            try
            {
                var consulta = _baseDataRepository
                    .Repositorio<OfertaProdutoEntity>()
                    .Consulta()
                    .Include(e => e.Produto)
                    .ThenInclude(e => e.Categoria)
                    .Where(e => !e.Inativo && e.IdOferta == idOferta);

                //pesquisas
                if (!string.IsNullOrWhiteSpace(busca))
                {
                    consulta = consulta.Where(e => EF.Functions.Like(e.Produto.Nome, $"%{busca}%"));
                }

                //agregacao
                //contagem antes da paginacao
                var total = consulta.Count();

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

                //modelo de dados
                var ofertaProdutoTabela = new OfertaProdutoDataTableDto();
                ofertaProdutoTabela.Tabela = consulta.ToList();
                ofertaProdutoTabela.TabelaTotal = total;
                ofertaProdutoTabela.PaginaAtual = index;
                ofertaProdutoTabela.PaginaExibe = exibe;
                return await Task.FromResult(ofertaProdutoTabela);

            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public async Task<OfertaProdutoDataTableDto> ListaPorFiltroAsync(int idOferta, int idCategoria, string busca, int index, int exibe, string ordem)
        {
            try
            {
                var consulta = _baseDataRepository
                    .Repositorio<OfertaProdutoEntity>()
                    .Consulta()
                    .Include(e => e.Produto)
                    .ThenInclude(e => e.Categoria)
                    .Where(e => !e.Inativo && e.IdOferta == idOferta && e.Produto.IdCategoria == idCategoria);

                //pesquisas
                if (!string.IsNullOrWhiteSpace(busca))
                {
                    consulta = consulta.Where(e => EF.Functions.Like(e.Produto.Nome, $"%{busca}%"));
                }

                //agregacao
                //contagem antes da paginacao
                var total = consulta.Count();

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

                //modelo de dados
                var ofertaProdutoTabela = new OfertaProdutoDataTableDto();
                ofertaProdutoTabela.Tabela = consulta.ToList();
                ofertaProdutoTabela.TabelaTotal = total;
                ofertaProdutoTabela.PaginaAtual = index;
                ofertaProdutoTabela.PaginaExibe = exibe;
                return await Task.FromResult(ofertaProdutoTabela);

            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public async Task<bool> SalvaTodosAsync(List<OfertaProdutoEntity> ofertaProdutos)
        {
            try
            {
                foreach (var ofertaProduto in ofertaProdutos)
                {
                    if (ofertaProduto.Id > 0)
                    {
                        _baseDataRepository
                        .Repositorio<OfertaProdutoEntity>()
                        .Atualiza(ofertaProduto);
                    }
                    else
                    {
                        _baseDataRepository
                        .Repositorio<OfertaProdutoEntity>()
                        .Adiciona(ofertaProduto);
                    }
                }                
                await _baseDataRepository
                    .Repositorio<OfertaProdutoEntity>()
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
