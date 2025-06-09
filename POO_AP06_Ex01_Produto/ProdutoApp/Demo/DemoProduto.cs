using System;
using Entidades;
using Repositorios;

namespace Demo
{
    public class DemoProduto
    {
        public static void Executar()
        {
            var repo = new ProdutoJsonRepository();

            var produto = new Produto
            {
                Nome = "Notebook",
                Descricao = "Notebook para desenvolvimento",
                Preco = 3500.50m,
                Estoque = 10
            };

            repo.Adicionar(produto);
            Console.WriteLine("Produto adicionado.");

            Console.WriteLine("Lista de produtos:");
            foreach (var p in repo.ObterTodos())
            {
                Console.WriteLine($"{p.Id} - {p.Nome} - R$ {p.Preco} - Estoque: {p.Estoque}");
            }

            var obtido = repo.ObterPorId(produto.Id);
            if (obtido != null)
            {
                Console.WriteLine($"Produto obtido: {obtido.Nome} - {obtido.Descricao}");
            }

            produto.Preco = 3000;
            repo.Atualizar(produto);
            Console.WriteLine("Produto atualizado.");

            repo.Remover(produto.Id);
            Console.WriteLine("Produto removido.");
        }
    }
}
