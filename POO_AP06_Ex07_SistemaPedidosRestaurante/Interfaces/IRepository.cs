using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepository<T> where T : IEntidade
    {
        void Adicionar(T entidade);
        List<T> Listar();
    }
}
