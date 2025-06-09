using System;
using Interfaces;

namespace Entidades
{
    public class Musica : IEntidade
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Artista { get; set; } = null!;
        public string Album { get; set; } = null!;
        public TimeSpan Duracao { get; set; }
    }
}
