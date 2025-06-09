using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Entidades;
using Interfaces;

namespace Repositorios
{
    public class ProdutoJsonRepository : IProdutoRepository
    {
        private readonly string _arquivo = "produtos.json";
        private List<Produto> _produtos;

        public ProdutoJsonRepository()
        {
            if (File.Exists(_arquivo))
            {
                var json = File.ReadAllText(_arquivo);
                _produtos = JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
            }
            else
            {
                _produtos = new List<Produto>();
            }
        }

        public void Adicionar(Produto produto)
        {
            produto.Id = Guid.NewGuid();
            _produtos.Add(produto);
            Salvar();
        }

        public Produto? ObterPorId(Guid id)
        {
            return _produtos.FirstOrDefault(p => p.Id == id);
        }

        public List<Produto> ObterTodos()
        {
            return _produtos;
        }

        public void Atualizar(Produto produto)
        {
            var index = _produtos.FindIndex(p => p.Id == produto.Id);
            if (index >= 0)
            {
                _produtos[index] = produto;
                Salvar();
            }
        }

        public bool Remover(Guid id)
        {
            var produto = ObterPorId(id);
            if (produto != null)
            {
                _produtos.Remove(produto);
                Salvar();
                return true;
            }
            return false;
        }

        private void Salvar()
        {
            var json = JsonSerializer.Serialize(_produtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_arquivo, json);
        }
    }
}
