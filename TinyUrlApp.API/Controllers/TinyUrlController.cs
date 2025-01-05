using Microsoft.AspNetCore.Mvc;
using TinyUrlApp.Application.Services;

namespace TinyUrlApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TinyUrlController : ControllerBase
{
    private readonly ShortUrlService _service;

    public TinyUrlController(ShortUrlService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateShortUrl([FromBody] string longUrl)
    {
        var shortCode = await _service.CreateShortUrlAsync(longUrl);
        return Ok(new { shortUrl = shortCode });
    }

    [HttpGet("{shortCode}")]
    public async Task<IActionResult> GetLongUrl(string shortCode)
    {
        var longUrl = await _service.GetLongUrlAsync(shortCode);
        if (longUrl == null) return NotFound();
        return Ok(new { longUrl });
    }
}
