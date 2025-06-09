using System;
using Interfaces;

namespace Entidades
{
    public class Paciente : IEntidade
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; } = "";
        public DateTime DataNascimento { get; set; }
        public string ContatoEmergencia { get; set; } = "";

        public int CalcularIdade()
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - DataNascimento.Year;
            if (DataNascimento.Date > hoje.AddYears(-idade)) idade--;
            return idade;
        }
    }
}
