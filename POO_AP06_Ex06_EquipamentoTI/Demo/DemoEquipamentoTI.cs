using Entidades;
using Repositorios;

namespace Demo
{
    public class DemoEquipamentoTI
    {
        public static void Executar()
        {
            var repo = new InMemoryEquipamentoTIRepository();

            repo.Adicionar(new EquipamentoTI
            {
                NomeEquipamento = "Notebook Dell",
                TipoEquipamento = "Notebook",
                NumeroSerie = "123ABC",
                DataAquisicao = new DateTime(2022, 5, 15)
            });

            repo.Adicionar(new EquipamentoTI
            {
                NomeEquipamento = "Monitor Samsung",
                TipoEquipamento = "Monitor",
                NumeroSerie = "456DEF",
                DataAquisicao = new DateTime(2023, 1, 10)
            });

            Console.WriteLine("Todos os equipamentos:");
            foreach (var eq in repo.ObterTodos())
            {
                Console.WriteLine($"{eq.NomeEquipamento} - {eq.TipoEquipamento} - {eq.NumeroSerie}");
            }
        }
    }
}
