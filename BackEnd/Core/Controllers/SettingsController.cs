namespace Core.Controllers;

using Core.Repository;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/settings")]
[ApiController]
public class SettingsController : ControllerBase
{
    private readonly ISettingsRepository _settingsRepository;

    public SettingsController(ISettingsRepository settingsRepository)
    {
        _settingsRepository = settingsRepository;
    }

    [HttpGet("get/bykey/{key}")]
    public async Task<ActionResult<SettingModel>> GetSettingByKey(string key)
    {
        var setting = await _settingsRepository.GetByKeyAsync(key);
        if (setting is null)
        {
            return NotFound();
        }
        return Ok(setting);
    }


    [HttpPost("update")]
    public async Task<IActionResult> UpdateSetting([FromBody] SettingModel setting)
    {
        await _settingsRepository.UpdateAsync(setting);
        return Ok();
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateProduct([FromBody] SettingModel setting)
    {
        await _settingsRepository.AddAsync(setting);
        return CreatedAtAction(nameof(GetSettingByKey), new { key = setting.Key }, setting);
    }
}
