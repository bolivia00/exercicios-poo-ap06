using Entidades;
using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repositorios
{
    public class ArquivoDigitalJsonRepository : GenericJsonRepository<ArquivoDigital>, IArquivoDigitalRepository
    {
        public ArquivoDigitalJsonRepository() : base("arquivosDigitais.json")
        {
        }

        public List<ArquivoDigital> BuscarPorTipo(string tipoArquivo)
        {
            return ObterTodos().Where(a => a.TipoArquivo == tipoArquivo).ToList();
        }
    }
}
