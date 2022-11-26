using CelleGames.Web.Models;

namespace CelleGames.Web.Services.IServices;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> FindAllProduct();
    Task<ProductModel> FindProductById(long id);
    Task<ProductModel> CreateProduct(ProductModel product); 
    Task<ProductModel> UpdateProduct(ProductModel product);
    Task<bool> DeleteProduct(long id);
}
