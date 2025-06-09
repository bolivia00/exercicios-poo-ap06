using Entidades;
using Repositorios;
using System;

namespace Demo
{
    public class Aplicacao
    {
        public void Executar()
        {
            var repositorio = new CursoOnlineJsonRepository();
            var servico = new CatalogoCursosService(repositorio);

            var curso = new CursoOnline
            {
                Id = Guid.NewGuid(),
                Titulo = "C# Avançado",
                Instrutor = "Ana Costa",
                CargaHorariaHoras = 25
            };

            servico.RegistrarCurso(curso);

            Console.WriteLine("\nCursos cadastrados:");
            servico.ListarCursos();
        }
    }
}
