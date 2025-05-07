namespace Products.Controllers;

using Core.DataModel.Models;
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
    public async Task<ActionResult<FullProductModel>> GetProductByID(int id)
    {
        var product = await _productsRepository.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProduct([FromBody] FullProductModel product)
    {
        await _productsRepository.AddAsync(product);
        return CreatedAtAction(nameof(GetProductByID), new { id = product.Id }, product);
    }

    [HttpPost("all")]
    public async Task<ActionResult<List<ListProductModel>>> GetAllProducts([FromBody] Paging paging)
    {
        var products = await _productsRepository.GetAllAsync(paging);
        return Ok(products);
    }
}
