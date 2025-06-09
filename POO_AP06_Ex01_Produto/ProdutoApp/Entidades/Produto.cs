using System;
using Interfaces;

namespace Entidades
{
    public class Produto : IEntidade
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}
