using Interfaces;

namespace Entidades;

public class Filme : IEntidade
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = "";
    public string Diretor { get; set; } = "";
    public int AnoLancamento { get; set; }
}
