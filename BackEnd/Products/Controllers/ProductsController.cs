namespace Products.Controllers;

using Microsoft.AspNetCore.Mvc;
using Products.DataModel.Entities;
using Products.Repository;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductsRepository _productRepository;

    public ProductsController(IProductsRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
        await _productRepository.AddAsync(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }
}
