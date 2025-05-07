namespace Events.Controllers;

using Microsoft.AspNetCore.Mvc;
using Events.DataModel.Models;
using Events.Repository;
using Core.DataModel.Models;
using AutoMapper;

[Route("api/events")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventsRepository _eventsRepository;
    private readonly IMapper _mapper;

    public EventsController(
        IEventsRepository eventRepository,
        IMapper mapper)
    {
        _eventsRepository = eventRepository;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FullEventModel>> GetEvent(int id)
    {
        var ev = await _eventsRepository.GetByIdAsync(id);
        if (ev == null) return NotFound();
        return Ok(ev);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateEvent([FromBody] EventForm eventForm)
    {
        var fullEvent = _mapper.Map<FullEventModel>(eventForm);
        await _eventsRepository.AddAsync(fullEvent);
        return CreatedAtAction(nameof(GetEvent), new { id = fullEvent.Id }, fullEvent);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateEvent([FromBody] EventForm eventForm)
    {
        var fullEvent = _mapper.Map<FullEventModel>(eventForm);
        await _eventsRepository.UpdateAsync(fullEvent);
        return Ok();
    }

    [HttpPost("all")]
    public async Task<ActionResult<List<ListEventModel>>> GetAllEvents([FromBody] Paging paging)
    {
        var events = await _eventsRepository.GetAllAsync(paging);
        return Ok(events);
    }

    [HttpPost("register")]
    public async Task<ActionResult<bool>> RegisterForEvent([FromBody] RegisterForEventForm eventRegistrationForm)
    {
        // TODO
        await Task.Delay(100);
        return Ok(true);
    }
}
