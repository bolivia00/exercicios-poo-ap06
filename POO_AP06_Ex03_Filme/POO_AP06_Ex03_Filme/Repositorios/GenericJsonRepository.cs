using System.Text.Json;
using Interfaces;

namespace Repositorios;

public class GenericJsonRepository<T> : IRepository<T> where T : IEntidade
{
    private readonly string _arquivo;
    private List<T> _lista;

    public GenericJsonRepository(string nomeArquivo)
    {
        _arquivo = nomeArquivo;
        _lista = File.Exists(_arquivo)
            ? JsonSerializer.Deserialize<List<T>>(File.ReadAllText(_arquivo)) ?? new List<T>()
            : new List<T>();
    }

    public void Adicionar(T entidade)
    {
        entidade.Id = Guid.NewGuid();
        _lista.Add(entidade);
        Salvar();
    }

    public T? ObterPorId(Guid id) => _lista.FirstOrDefault(e => e.Id == id);

    public List<T> ObterTodos() => _lista;

    public void Atualizar(T entidade)
    {
        var index = _lista.FindIndex(e => e.Id == entidade.Id);
        if (index >= 0)
        {
            _lista[index] = entidade;
            Salvar();
        }
    }

    public bool Remover(Guid id)
    {
        var entidade = ObterPorId(id);
        if (entidade != null)
        {
            _lista.Remove(entidade);
            Salvar();
            return true;
        }
        return false;
    }

    private void Salvar()
    {
        var json = JsonSerializer.Serialize(_lista, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_arquivo, json);
    }
}
