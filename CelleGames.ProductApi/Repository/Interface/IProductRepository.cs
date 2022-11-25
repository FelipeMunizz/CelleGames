
using CelleGames.ProductApi.DataVO.ValueObjects;

namespace CelleGames.ProductApi.Repository.Interface;

public interface IProductRepository
{
    Task<IEnumerable<ProductVO>> FindAll();
    Task<ProductVO> FindById(long id);
    Task<ProductVO> Create(ProductVO productVO);
    Task<ProductVO> Update(ProductVO productVO);
    Task<bool> Delete(long id);
}