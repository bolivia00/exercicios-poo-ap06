using Entidades;
using Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repositorios
{
    public class ReservaHotelJsonRepository : GenericJsonRepository<ReservaHotel>, IReservaHotelRepository
    {
        public ReservaHotelJsonRepository() : base("reservasHotel.json")
        {
        }

        public List<ReservaHotel> ObterPorStatus(string status)
        {
            return ObterTodos().Where(r => r.Status?.ToLower() == status.ToLower()).ToList();
        }
    }
}
