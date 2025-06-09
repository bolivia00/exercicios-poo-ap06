using System;
using Entidades;
using Repositorios;

namespace Demo
{
    public static class DemoMusica
    {
        public static void ExecutarDemo()
        {
            var repo = new GenericJsonRepository<Musica>("musicas.json");

            // Criar uma música
            var musica = new Musica
            {
                Titulo = "Imagine",
                Artista = "John Lennon",
                Album = "Imagine"
            };

            // Adicionar música
            repo.Adicionar(musica);
            Console.WriteLine("Música adicionada.");

            // Listar músicas
            var lista = repo.ObterTodos();
            Console.WriteLine("Lista de músicas:");
            foreach (var m in lista)
            {
                Console.WriteLine($"{m.Id} - {m.Titulo} - {m.Artista} - {m.Album}");
            }

            // Obter por ID
            var obtido = repo.ObterPorId(musica.Id);
            if (obtido != null)
            {
                Console.WriteLine($"Música obtida: {obtido.Titulo} - {obtido.Artista} - {obtido.Album}");
            }

            // Atualizar música
            obtido.Album = "Imagine (Remastered)";
            repo.Atualizar(obtido);
            Console.WriteLine("Música atualizada.");

            // Remover música
            repo.Remover(obtido.Id);
            Console.WriteLine("Música removida.");
        }
    }
}
