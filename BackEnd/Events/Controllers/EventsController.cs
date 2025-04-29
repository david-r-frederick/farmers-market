namespace Events.Controllers;

using Microsoft.AspNetCore.Mvc;
using Events.DataModel.Models;
using Events.Repository;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventsRepository _eventsRepository;

    public EventsController(IEventsRepository eventRepository)
    {
        _eventsRepository = eventRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FullEventModel>> GetEvent(int id)
    {
        var ev = await _eventsRepository.GetByIdAsync(id);
        if (ev == null) return NotFound();
        return Ok(ev);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] FullEventModel ev)
    {
        await _eventsRepository.AddAsync(ev);
        return CreatedAtAction(nameof(GetEvent), new { id = ev.Id }, ev);
    }
}
