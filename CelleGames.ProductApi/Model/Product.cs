using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CelleGames.ProductApi.Model;

public class Product : BaseEntity
{
    [Required(ErrorMessage = "Digite um Nome")]
    [StringLength(150)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Digite um Preço")]
    [Range(1,10000)]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Digite a Descrição do Produto")]
    [StringLength(500)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Imagem é obrigatório")]
    [StringLength(300)]
    public string? ImageUrl { get; set; }

    public float Inventory { get; set; }
    public DateTime DateRegister { get; set; }

    // Definindo relacionamento entre as tabelas
    public int CategoryId { get; set; }

    [JsonIgnore]
    public Category? Category { get; set; }
}
