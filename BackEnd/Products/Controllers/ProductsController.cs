namespace Products.Controllers;

using Microsoft.AspNetCore.Mvc;
using Products.DataModel.Models;
using Products.Repository;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductsRepository _productsRepository;

    public ProductsController(IProductsRepository productRepository)
    {
        _productsRepository = productRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductModel>> GetProductByID(int id)
    {
        var product = await _productsRepository.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductModel product)
    {
        await _productsRepository.AddAsync(product);
        return CreatedAtAction(nameof(GetProductByID), new { id = product.Id }, product);
    }
}
