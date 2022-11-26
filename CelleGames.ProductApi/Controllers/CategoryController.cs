using CelleGames.ProductApi.DataVO.ValueObjects;
using CelleGames.ProductApi.Model;
using CelleGames.ProductApi.Repository;
using CelleGames.ProductApi.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CelleGames.ProductApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository ??
            throw new ArgumentException(nameof(categoryRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryVO>>> FindAll()
    {
        var categories = await _categoryRepository.FindAll();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryVO>> FindById(int id)
    {
        var category = await _categoryRepository.FindById(id);
        if (category == null)
        {
            return NotFound("Nenhum Produto Encontrado");
        }
        return Ok(category);
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryVO>>> FindCategoryProducts()
    {
        var categoryProducts = await _categoryRepository.FindCategoryProducts();
        return Ok(categoryProducts);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryVO>> Create(CategoryVO categoryVO)
    {
        if (categoryVO == null)
            return BadRequest();

        var category = await _categoryRepository.Create(categoryVO);
        return Ok(category);
    }

    [HttpPut]
    public async Task<ActionResult<CategoryVO>> Update(CategoryVO categoryVO)
    {
        if (categoryVO == null)
            return BadRequest();

        var category = await _categoryRepository.Update(categoryVO);
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var status = await _categoryRepository.Delete(id);
        if (!status)
            return BadRequest("Id incorreto");
        return Ok(status);
    }
}
