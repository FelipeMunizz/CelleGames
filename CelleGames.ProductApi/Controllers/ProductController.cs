using CelleGames.ProductApi.DataVO.ValueObjects;
using CelleGames.ProductApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CelleGames.ProductApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? 
            throw new ArgumentException(nameof(productRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
    {
        var products = await _productRepository.FindAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductVO>>FindById(long id)
    {
        var product = await _productRepository.FindById(id);
        if(product== null)
        {
            return NotFound("Nenhum Produto Encontrado");
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductVO>> Create(ProductVO productVo)
    {
        if(productVo == null)        
            return BadRequest();

        var product = await _productRepository.Create(productVo);
        return Ok(product);
    }

    [HttpPut]
    public async Task<ActionResult<ProductVO>> Update(ProductVO productVo)
    {
        if (productVo == null)
            return BadRequest();

        var product = await _productRepository.Update(productVo);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var status = await _productRepository.Delete(id);
        if (!status)
            return BadRequest("Id incorreto");
        return Ok(status);
    }
}
