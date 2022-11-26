using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CelleGames.ProductApi.Model
{
    public class Category
    {
        // Inicialização da Coleção Produto
        public Category()
        {
            Products = new Collection<Product>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100)]
        public string? Name { get; set; }

        // Definindo relacionamento entre as tabelas
        public ICollection<Product>? Products { get; set; }
    }
}
