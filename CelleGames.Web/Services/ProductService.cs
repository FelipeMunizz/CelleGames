using CelleGames.Web.Models;
using CelleGames.Web.Services.IServices;
using CelleGames.Web.Utils;

namespace CelleGames.Web.Services;
public class ProductService : IProductService
{
    private readonly HttpClient _client;
    public const string baseUrl = "api/v1/Product";

    public ProductService(HttpClient client)
    {
        _client = client ?? throw new ArgumentException(nameof(client)); ;
    }

    public async Task<IEnumerable<ProductModel>> FindAllProduct()
    {
        var response = await _client.GetAsync(baseUrl);
        return await response.ReadContentAs<List<ProductModel>>();
    }

    public async Task<ProductModel> FindProductById(long id)
    {
        var response = await _client.GetAsync($"{baseUrl}/{id}");
        return await response.ReadContentAs<ProductModel>();
    }

    public async Task<ProductModel> CreateProduct(ProductModel product)
    {
        var response = await _client.PostAsJson(baseUrl, product);
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<ProductModel>();
        throw new Exception("Não foi possivel se comunicar com a API");
    }
    public async Task<ProductModel> UpdateProduct(ProductModel product)
    {
        var response = await _client.PutAsJson(baseUrl, product);
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<ProductModel>();
        throw new Exception("Não foi possivel se comunicar com a API");
    }

    public async Task<bool> DeleteProduct(long id)
    {
        var response = await _client.DeleteAsync($"{baseUrl}/{id}");
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<bool>();
        throw new Exception("Não foi possivel se comunicar com a API");
    }
}
