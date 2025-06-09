using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Repositorios
{
    public class GenericJsonRepository<T> : IRepository<T> where T : IEntidade
    {
        private readonly string _caminhoArquivo;

        public GenericJsonRepository(string caminhoArquivo)
        {
            _caminhoArquivo = caminhoArquivo;
        }

        public void Adicionar(T entidade)
        {
            var dados = Listar();
            dados.Add(entidade);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true,
                PropertyNameCaseInsensitive = true
            };
            File.WriteAllText(_caminhoArquivo, JsonSerializer.Serialize(dados, options));
        }

        public List<T> Listar()
        {
            if (!File.Exists(_caminhoArquivo))
                return new List<T>();

            var json = File.ReadAllText(_caminhoArquivo);
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                PropertyNameCaseInsensitive = true
            };
return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
        }
    }
}
