using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Interfaces;
using Entidades;

namespace Repositorios
{
    public class PacienteJsonRepository : IPacienteRepository
    {
        private readonly string _arquivo = "pacientes.json";
        private List<Paciente> _lista;

        public PacienteJsonRepository()
        {
            if (File.Exists(_arquivo))
            {
                var json = File.ReadAllText(_arquivo);
                _lista = JsonSerializer.Deserialize<List<Paciente>>(json) ?? new List<Paciente>();
            }
            else
            {
                _lista = new List<Paciente>();
            }
        }

        public void Adicionar(Paciente entidade)
        {
            entidade.Id = Guid.NewGuid();
            _lista.Add(entidade);
            Salvar();
        }

        public Paciente? ObterPorId(Guid id)
        {
            return _lista.FirstOrDefault(e => e.Id == id);
        }

        public List<Paciente> ObterTodos()
        {
            return _lista;
        }

        public void Atualizar(Paciente entidade)
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

        public IEnumerable<Paciente> ObterPorFaixaEtaria(int idadeMin, int idadeMax)
        {
            return _lista.Where(p =>
            {
                var idade = p.CalcularIdade();
                return idade >= idadeMin && idade <= idadeMax;
            });
        }

        private void Salvar()
        {
            var json = JsonSerializer.Serialize(_lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_arquivo, json);
        }
    }
}
