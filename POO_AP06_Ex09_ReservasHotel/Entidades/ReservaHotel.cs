using System;

namespace Entidades
{
    public class ReservaHotel
    {
        public Guid Id { get; set; }
        public string? NomeCliente { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public string? Status { get; set; }  // Usando string em vez de enum
    }
}
