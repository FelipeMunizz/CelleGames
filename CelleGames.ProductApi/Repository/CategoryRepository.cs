using AutoMapper;
using CelleGames.ProductApi.Data;
using CelleGames.ProductApi.DataVO.ValueObjects;
using CelleGames.ProductApi.Model;
using CelleGames.ProductApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CelleGames.ProductApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public CategoryRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryVO>> FindAll()
        {
            List<Category> categories = await _context.Categories.ToListAsync();
            return _mapper.Map<List<CategoryVO>>(categories);
        }

        public async Task<CategoryVO> FindById(int id)
        {
            Category? category = await _context.Categories.Where(p => p.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<CategoryVO>(category);
        }
        public async Task<IEnumerable<CategoryVO>> FindCategoryProducts()
        {
            List<Category> categoriesProducts = await _context.Categories.Include(x => x.Products).ToListAsync();
            return _mapper.Map<List<CategoryVO>>(categoriesProducts);
        }

        public async Task<CategoryVO> Create(CategoryVO categoryVO)
        {
            Category? category = _mapper.Map<Category>(categoryVO);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryVO>(category);
        }


        public async Task<CategoryVO> Update(CategoryVO categoryVO)
        {
            Category? category = _mapper.Map<Category>(categoryVO);
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryVO>(category);
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                Category? category = await _context.Categories.Where(p => p.CategoryId == id).FirstOrDefaultAsync();
                if (category == null)
                    return false;
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }        
    }
}
