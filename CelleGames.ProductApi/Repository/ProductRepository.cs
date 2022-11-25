using AutoMapper;
using CelleGames.ProductApi.Data;
using CelleGames.ProductApi.DataVO.ValueObjects;
using CelleGames.ProductApi.Model;
using CelleGames.ProductApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CelleGames.ProductApi.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    private IMapper _mapper;

    public ProductRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductVO>> FindAll()
    {
        List<Product> products = await _context.Products.ToListAsync() ;
        return _mapper.Map<List<ProductVO>>(products);
    }

    public async Task<ProductVO> FindById(long id)
    {
        Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<ProductVO>(product);
    }

    public async Task<ProductVO> Create(ProductVO productVO)
    {
        Product product = _mapper.Map<Product>(productVO);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return _mapper.Map<ProductVO>(product);
    }


    public async Task<ProductVO> Update(ProductVO productVO)
    {
        Product product = _mapper.Map<Product>(productVO);
        _context.Products.Update(product);
        await _context.SaveChangesAsync();

        return _mapper.Map<ProductVO>(product);
    }
    public async Task<bool> Delete(long id)
    {
        try
        {
            Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            if(product == null)
                return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
