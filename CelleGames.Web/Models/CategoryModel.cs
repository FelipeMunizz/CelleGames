using System.Collections.ObjectModel;

namespace CelleGames.Web.Models;

public class CategoryModel
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public ICollection<ProductModel>? Products { get; set; }
}
