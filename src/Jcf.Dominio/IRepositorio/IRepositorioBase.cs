using System;
using System.Collections.Generic;
namespace Jcf.Dominio.IRepositorio
{
    public interface IRepositorioBase<T> where T : class
    {
        List<T>? ObteTodos();
        T? Obter(Guid id);
        Task<T> AdicionarAsync(T entity);
        Task<T> AtualizarAsync(T entity);
        Task<T> ApagarAsync(T entity);
    }
}
