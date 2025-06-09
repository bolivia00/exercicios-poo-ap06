using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Repositorios
{
    public class GenericJsonRepository<T> where T : class
    {
        protected readonly string _caminhoArquivo;

        public GenericJsonRepository(string caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo;
        }

        public virtual void Adicionar(T entidade)
        {
            var lista = ObterTodos();
            lista.Add(entidade);
            var json = JsonSerializer.Serialize(lista);
            File.WriteAllText(_caminhoArquivo, json);
        }

        public virtual List<T> ObterTodos()
        {
            if (!File.Exists(_caminhoArquivo)) return new List<T>();
            var json = File.ReadAllText(_caminhoArquivo);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
    }
}
