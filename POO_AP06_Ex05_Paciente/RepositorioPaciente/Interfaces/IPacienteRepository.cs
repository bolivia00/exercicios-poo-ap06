using System;
using System.Collections.Generic;
using Entidades;

namespace Interfaces
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        IEnumerable<Paciente> ObterPorFaixaEtaria(int idadeMin, int idadeMax);
    }
}
