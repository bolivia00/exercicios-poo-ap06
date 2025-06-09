using System;
using Interfaces;
using Entidades;
using Repositorios;

namespace Demo
{
    public class DemoPaciente
    {
        public static void Executar()
        {
            IPacienteRepository repo = new PacienteJsonRepository();

            var p1 = new Paciente
            {
                NomeCompleto = "João da Silva",
                DataNascimento = new DateTime(1985, 4, 20),
                ContatoEmergencia = "9999-9999"
            };

            var p2 = new Paciente
            {
                NomeCompleto = "Maria Oliveira",
                DataNascimento = new DateTime(2000, 10, 15),
                ContatoEmergencia = "9888-8888"
            };

            repo.Adicionar(p1);
            repo.Adicionar(p2);

            Console.WriteLine("Pacientes adicionados.");
            Console.WriteLine("Todos os pacientes:");
            foreach (var p in repo.ObterTodos())
            {
                Console.WriteLine($"{p.NomeCompleto} - Idade: {p.CalcularIdade()} anos");
            }

            Console.WriteLine("Pacientes entre 20 e 40 anos:");
            foreach (var p in repo.ObterPorFaixaEtaria(20, 40))
            {
                Console.WriteLine($"{p.NomeCompleto} - Idade: {p.CalcularIdade()} anos");
            }
        }
    }
}
