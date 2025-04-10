namespace WebApp;

using Microsoft.AspNetCore.Mvc;
using Context;
using NSwag.Annotations;

[ApiController]
[Route("[controller]")]
public class StartingController : ControllerBase
{
    private readonly FarmersMarketDb _context;

    public StartingController(FarmersMarketDb context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("test-connection")]
    [OpenApiOperation(operationId: "starting_TestConnection")]
    public ActionResult<ConnectedResponse> TestConnection()
    {
        var canConnect = _context.CanConnect();
        return Ok(new { Connected = canConnect });
    }
}

public class ConnectedResponse
{
    public bool Connected { get; set; }
}