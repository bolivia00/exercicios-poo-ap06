using Entidades;
using Interfaces;
using System.Collections.Generic;

namespace Repositorios
{
    public class CursoOnlineJsonRepository : GenericJsonRepository<CursoOnline>, ICursoOnlineRepository
    {
        public CursoOnlineJsonRepository() : base("cursosOnline.json")
        {
        }
    }
}
