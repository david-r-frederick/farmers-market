using Context;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace WebApp.Controllers;

public class WebAppController : ControllerBase
{
    private readonly FarmersMarketDb _context;

    public WebAppController(FarmersMarketDb context)
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

    public class ConnectedResponse
    {
        public bool Connected { get; set; }
    }
}
