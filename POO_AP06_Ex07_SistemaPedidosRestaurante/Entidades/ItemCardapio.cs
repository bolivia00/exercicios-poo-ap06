using Interfaces;
using System.Text.Json.Serialization;

namespace Entidades
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$tipo")]
    [JsonDerivedType(typeof(Prato), typeDiscriminator: "prato")]
    [JsonDerivedType(typeof(Bebida), typeDiscriminator: "bebida")]
    public abstract class ItemCardapio : IEntidade
    {
        public Guid Id { get; set; }
        public string NomeItem { get; set; } = string.Empty;
        public decimal Preco { get; set; }
    }
}
