namespace Categories.Controllers;

using Microsoft.AspNetCore.Mvc;
using Categories.DataModel.Entities;
using Categories.Repository;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesRepository _categoriesRepository;

    public CategoriesController(ICategoriesRepository categoryRepository)
    {
        _categoriesRepository = categoryRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategoryByID(int id)
    {
        var category = await _categoriesRepository.GetByIdAsync(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] Category category)
    {
        await _categoriesRepository.AddAsync(category);
        return CreatedAtAction(nameof(GetCategoryByID), new { id = category.Id }, category);
    }
}
