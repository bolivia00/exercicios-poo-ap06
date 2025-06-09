using Interfaces;
using System;

namespace Entidades
{
    public class Departamento : IEntidade
    {
        public Guid Id { get; set; }
        public string NomeDepartamento { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
    }
}
