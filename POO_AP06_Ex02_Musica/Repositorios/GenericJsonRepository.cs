using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Interfaces;

namespace Repositorios
{
    public class GenericJsonRepository<T> : IRepository<T> where T : IEntidade
    {
        private readonly string _arquivo;
        private List<T> _lista;

        public GenericJsonRepository(string nomeArquivo)
        {
            _arquivo = nomeArquivo;

            if (File.Exists(_arquivo))
            {
                var json = File.ReadAllText(_arquivo);
                _lista = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            else
            {
                _lista = new List<T>();
            }
        }

        public void Adicionar(T entidade)
        {
            entidade.Id = Guid.NewGuid();
            _lista.Add(entidade);
            Salvar();
        }

        public T? ObterPorId(Guid id)
        {
            return _lista.FirstOrDefault(e => e.Id == id);
        }

        public List<T> ObterTodos()
        {
            return _lista;
        }

        public void Atualizar(T entidade)
        {
            var index = _lista.FindIndex(e => e.Id == entidade.Id);
            if (index >= 0)
            {
                _lista[index] = entidade;
                Salvar();
            }
        }

        public bool Remover(Guid id)
        {
            var entidade = ObterPorId(id);
            if (entidade != null)
            {
                _lista.Remove(entidade);
                Salvar();
                return true;
            }
            return false;
        }

        private void Salvar()
        {
            var json = JsonSerializer.Serialize(_lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_arquivo, json);
        }
    }
}
