namespace Events.Controllers;

using Events.DataModel.Models;
using Events.Repository;
using Microsoft.AspNetCore.Mvc;

[Route("api/vendors")]
[ApiController]
public class VendorsController : ControllerBase
{
    private readonly IVendorsRepository _vendorsRepository;

    public VendorsController(IVendorsRepository vendorsRepository)
    {
        _vendorsRepository = vendorsRepository;
    }

    [HttpPost("register")]
    public async Task<ActionResult<int>> RegisterAsVendor([FromBody] VendorRegistrationFormData formData)
    {
        var userId = await _vendorsRepository.RegisterVendor(formData);
        return Ok(userId);
    }
}
