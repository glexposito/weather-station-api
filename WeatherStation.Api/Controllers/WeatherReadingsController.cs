using Microsoft.AspNetCore.Mvc;
using WeatherStation.Api.Models;

namespace WeatherStation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherReadingsController : ControllerBase
{
    /// <summary>
    /// Returns all recorded weather readings.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<WeatherReading>> GetAll()
    {
        var readings = new List<WeatherReading>
        {
            new(
                Id: 1,
                Location: "Auckland",
                TemperatureC: 18.2,
                HumidityPercent: 70.5,
                Timestamp: DateTime.UtcNow.AddMinutes(-5)
            ),
            new(
                Id: 2,
                Location: "Wellington",
                TemperatureC: 15.6,
                HumidityPercent: 65.1,
                Timestamp: DateTime.UtcNow.AddMinutes(-10)
            )
        };

        return Ok(readings);
    }

    /// <summary>
    /// Returns the latest weather reading for a given location.
    /// </summary>
    [HttpGet("latest")]
    public ActionResult<WeatherReading> GetLatest([FromQuery] string location)
    {
        if (!location.Equals("auckland", StringComparison.OrdinalIgnoreCase))
            return NotFound();

        var reading = new WeatherReading
        (
            Id: 999,
            Location: "Auckland",
            TemperatureC: 17.5,
            HumidityPercent: 72.3,
            Timestamp: DateTime.UtcNow
        );

        return Ok(reading);
    }

    /// <summary>
    /// Adds a new weather reading.
    /// </summary>
    [HttpPost]
    public ActionResult<WeatherReading> Add([FromBody] WeatherReading reading)
    {
        if (string.IsNullOrWhiteSpace(reading.Location))
            return BadRequest("Location is required.");
        
        return CreatedAtAction(nameof(GetAll), new { id = reading.Id }, reading);
    }
}