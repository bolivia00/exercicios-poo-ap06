using Entidades;
using Repositorios;

namespace Demo;

public class DemoFilme
{
    public static void Executar()
    {
        var repo = new GenericJsonRepository<Filme>("filmes.json");

        var filme = new Filme
        {
            Titulo = "A Origem",
            Diretor = "Christopher Nolan",
            AnoLancamento = 2010
        };

        repo.Adicionar(filme);
        Console.WriteLine("Filme adicionado.");

        Console.WriteLine("Lista de filmes:");
        foreach (var f in repo.ObterTodos())
        {
            Console.WriteLine($"{f.Id} - {f.Titulo} ({f.AnoLancamento}) - Direção: {f.Diretor}");
        }

        var obtido = repo.ObterPorId(filme.Id);
        if (obtido != null)
        {
            Console.WriteLine($"Filme obtido: {obtido.Titulo} - {obtido.Diretor}");
        }

        filme.Titulo = "A Origem (Inception)";
        repo.Atualizar(filme);
        Console.WriteLine("Filme atualizado.");

        repo.Remover(filme.Id);
        Console.WriteLine("Filme removido.");
    }
}
