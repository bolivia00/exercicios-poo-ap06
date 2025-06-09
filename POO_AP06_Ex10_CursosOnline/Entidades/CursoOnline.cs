using System;

namespace Entidades
{
    public class CursoOnline
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Instrutor { get; set; }
        public int CargaHorariaHoras { get; set; }
    }
}
