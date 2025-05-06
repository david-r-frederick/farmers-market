namespace Customers.Controllers;

using Customers.DataModel.Entities;
using Customers.Repository;
using Microsoft.AspNetCore.Mvc;

[Route("api/customers")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomersRepository _customersRepository;

    public CustomersController(ICustomersRepository customersRepository)
    {
        _customersRepository = customersRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomerByID(int id)
    {
        var product = await _customersRepository.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }
}
