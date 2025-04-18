﻿namespace Geography.Controllers;

using Microsoft.AspNetCore.Mvc;
using Geography.DataModel.Entities;
using Geography.Repository;

[Route("api/addresses")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IAddressesRepository _addressesRepository;

    public AddressesController(IAddressesRepository addressesRepository)
    {
        _addressesRepository = addressesRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Address>> GetAddressByID(int id)
    {
        var address = await _addressesRepository.GetByIdAsync(id);
        if (address == null) return NotFound();
        return Ok(address);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAddress([FromBody] Address address)
    {
        await _addressesRepository.AddAsync(address);
        return CreatedAtAction(nameof(GetAddressByID), new { id = address.Id }, address);
    }
}
