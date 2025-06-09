using Entidades;
using Repositorios;
using System;

namespace Demo
{
    public static class DemoFuncionarioDepartamento
    {
        public static void Executar()
        {
            var repoDepto = new GenericJsonRepository<Departamento>("departamentos.json");
            var repoFunc = new GenericJsonRepository<Funcionario>("funcionarios.json");

            // Criar e adicionar departamentos
            var depto1 = new Departamento { NomeDepartamento = "Tecnologia da Informação", Sigla = "TI" };
            var depto2 = new Departamento { NomeDepartamento = "Recursos Humanos", Sigla = "RH" };

            repoDepto.Adicionar(depto1);
            repoDepto.Adicionar(depto2);

            // Criar e adicionar funcionários
            var func1 = new Funcionario { NomeCompleto = "João Silva", Cargo = "Desenvolvedor", DepartamentoId = depto1.Id };
            var func2 = new Funcionario { NomeCompleto = "Maria Souza", Cargo = "Analista RH", DepartamentoId = depto2.Id };

            repoFunc.Adicionar(func1);
            repoFunc.Adicionar(func2);

            // Listar funcionários com seu departamento
            Console.WriteLine("Funcionários:");
            foreach (var f in repoFunc.ObterTodos())
            {
                var depto = repoDepto.ObterPorId(f.DepartamentoId);
                Console.WriteLine($"{f.NomeCompleto} - {f.Cargo} - Departamento: {depto?.Sigla}");
            }
        }
    }
}
