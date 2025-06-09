using System.Collections.Generic;
using Entidades;

namespace Interfaces
{
    public interface IReservaHotelRepository
    {
        void Adicionar(ReservaHotel reserva);
        List<ReservaHotel> ObterTodos();
        List<ReservaHotel> ObterPorStatus(string status);
    }
}
