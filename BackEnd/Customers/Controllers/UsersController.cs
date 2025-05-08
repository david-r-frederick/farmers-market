namespace Customers.Controllers;

using Microsoft.AspNetCore.Mvc;
using Customers.DataModel.Entities;
using Customers.DataModel.Models;
using Customers.Repository;

[Route("api/users")]
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

    [HttpPost("log-in")]
    public async Task<ActionResult<bool>> LogIn([FromBody] LogInRequest logInRequest)
    {
        var success = await _usersRepository.LogInAsync(logInRequest.UserName, logInRequest.Password);
        if (!success)
        {
            return BadRequest(false);
        }
        return Ok(success);
    }
}
