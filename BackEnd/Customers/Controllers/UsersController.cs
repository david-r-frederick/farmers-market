namespace Customers.Controllers;

using Customers.DataModel.Entities;
using Customers.Repository;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;

    public UsersController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserByID(int id)
    {
        var product = await _usersRepository.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }
}
