using System;

namespace Flyers.Core.Interfaces.DataRepositories
{
    public interface IDataRepository : IDisposable
    {
        //Instancia dinamica para os repositorios de dados
        IRepository<T> Repositorio<T>() where T : class;
        // Método de Commit do contexto
        bool ConfirmaOuReverteTodos();
    }
}