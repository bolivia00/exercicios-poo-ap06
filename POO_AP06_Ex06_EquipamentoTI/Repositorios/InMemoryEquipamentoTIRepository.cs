using Interfaces;
using Entidades;

namespace Repositorios
{
    public class InMemoryEquipamentoTIRepository : IEquipamentoTIRepository
    {
        private readonly List<EquipamentoTI> _equipamentos = new();

        public void Adicionar(EquipamentoTI equipamento)
        {
            equipamento.Id = Guid.NewGuid();
            _equipamentos.Add(equipamento);
        }

        public EquipamentoTI? ObterPorId(Guid id)
        {
            return _equipamentos.FirstOrDefault(e => e.Id == id);
        }

        public List<EquipamentoTI> ObterTodos()
        {
            return _equipamentos;
        }

        public void Atualizar(EquipamentoTI equipamento)
        {
            var index = _equipamentos.FindIndex(e => e.Id == equipamento.Id);
            if (index >= 0)
                _equipamentos[index] = equipamento;
        }

        public bool Remover(Guid id)
        {
            var equipamento = ObterPorId(id);
            if (equipamento != null)
                return _equipamentos.Remove(equipamento);
            return false;
        }
    }
}
