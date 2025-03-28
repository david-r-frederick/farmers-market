﻿using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers;

[ApiController]
[Route("starting")]
public class StartingController : ControllerBase
{
    private readonly FarmersMarketDb _context;

    public StartingController(FarmersMarketDb context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("test-connection")]
    public IActionResult TestConnection()
    {
        var canConnect = _context.CanConnect();
        return Ok(new { Connected = canConnect });
    }
}
