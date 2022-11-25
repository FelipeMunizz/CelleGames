using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CelleGames.ProductApi.Model
{
    public class Category : BaseEntity
    {
        public class Categoria
        {
            // Inicialização da Coleção Produto
            public Categoria()
            {
                Products = new Collection<Product>();
            }

            public int CategoriaId { get; set; }

            [Required(ErrorMessage = "Nome é obrigatório")]
            [StringLength(100)]
            public string? Nome { get; set; }

            // Definindo relacionamento entre as tabelas
            public ICollection<Product>? Products { get; set; }
        }
    }
}
