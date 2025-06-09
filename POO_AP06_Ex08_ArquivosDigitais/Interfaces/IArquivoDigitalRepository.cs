using System.Collections.Generic;
using Entidades;

namespace Interfaces
{
    public interface IArquivoDigitalRepository
    {
        void Adicionar(ArquivoDigital arquivo);
        List<ArquivoDigital> ObterTodos();
        List<ArquivoDigital> BuscarPorTipo(string tipoArquivo);
    }
}
