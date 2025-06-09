using Entidades;
using Repositorios;
using System;
using System.Collections.Generic;

namespace Demo
{
    public static class Demo
    {
        public static void Executar()
        {
            var repositorio = new GenericJsonRepository<ItemCardapio>("cardapio.json");

            var prato = new Prato
            {
                Id = Guid.NewGuid(),
                NomeItem = "Feijoada",
                Preco = 30.00m,
                DescricaoDetalhada = "Feijoada completa com acompanhamentos.",
                Vegetariano = false
            };

            var bebida = new Bebida
            {
                Id = Guid.NewGuid(),
                NomeItem = "Suco de Laranja",
                Preco = 8.00m,
                VolumeMl = 300,
                Alcoolica = false
            };

            repositorio.Adicionar(prato);
            repositorio.Adicionar(bebida);

            Console.WriteLine("=== Itens do Cardápio ===");
            List<ItemCardapio> itens = repositorio.Listar();
            foreach (var item in itens)
            {
                Console.WriteLine($"- {item.NomeItem} | Preço: {item.Preco:C}");
            }
        }
    }
}
