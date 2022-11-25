using CelleGames.ProductApi.DataVO.ValueObjects;

namespace CelleGames.ProductApi.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryVO>> FindAll();
        Task<CategoryVO> FindById(int id);
        Task<CategoryVO> Create(CategoryVO categoryVO);
        Task<CategoryVO> Update(CategoryVO categoryVO);
        Task<bool> Delete(int id);
    }
}
