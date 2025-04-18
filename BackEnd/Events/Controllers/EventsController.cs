﻿namespace Events.Controllers;

using Microsoft.AspNetCore.Mvc;
using Events.DataModel.Entities;
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
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        var ev = await _eventsRepository.GetByIdAsync(id);
        if (ev == null) return NotFound();
        return Ok(ev);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] Event ev)
    {
        await _eventsRepository.AddAsync(ev);
        return CreatedAtAction(nameof(GetEvent), new { id = ev.Id }, ev);
    }
}
