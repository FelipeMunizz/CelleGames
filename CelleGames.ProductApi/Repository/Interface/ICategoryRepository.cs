using CelleGames.ProductApi.DataVO.ValueObjects;

namespace CelleGames.ProductApi.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryVO>> FindAll();
        Task<CategoryVO> FindById(long id);
        Task<CategoryVO> Create(CategoryVO categoryVO);
        Task<CategoryVO> Update(CategoryVO categoryVO);
        Task<bool> Delete(long id);
    }
}
