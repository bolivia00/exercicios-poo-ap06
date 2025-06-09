using Entidades;
using Interfaces;
using Repositorios;
using System;

namespace Demo
{
    public class Aplicacao
    {
        public void Executar()
        {
            IReservaHotelRepository repo = new ReservaHotelJsonRepository();

            var reserva = new ReservaHotel
            {
                Id = Guid.NewGuid(),
                NomeCliente = "Maria Souza",
                DataEntrada = DateTime.Today,
                DataSaida = DateTime.Today.AddDays(2),
                Status = "confirmada"
            };

            repo.Adicionar(reserva);

            var confirmadas = repo.ObterPorStatus("confirmada");

            Console.WriteLine("Reservas confirmadas:");
            foreach (var r in confirmadas)
            {
                Console.WriteLine($"{r.NomeCliente} - Entrada: {r.DataEntrada:dd/MM/yyyy}, Saída: {r.DataSaida:dd/MM/yyyy}");
            }
        }
    }
}
