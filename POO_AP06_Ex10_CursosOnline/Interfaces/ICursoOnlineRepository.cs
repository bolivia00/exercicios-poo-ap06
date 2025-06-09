using System.Collections.Generic;
using Entidades;

namespace Interfaces
{
    public interface ICursoOnlineRepository
    {
        void Adicionar(CursoOnline curso);
        List<CursoOnline> ObterTodos();
    }
}
