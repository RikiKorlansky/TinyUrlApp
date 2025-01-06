using Microsoft.AspNetCore.Mvc;

namespace TinyUrlApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TinyUrlController : ControllerBase
{
    private readonly IShortUrlService _shortUrlService;


    public TinyUrlController(ShortUrlService service)
    {
        _shortUrlService = service;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateShortUrls(int batchSize = 1_000_000)
    {
        await _shortUrlService.GenerateSequentialShortUrlsAsync(batchSize);
        return Ok("Short URLs generated successfully!");
    }
    [HttpGet("get-short-url/{url}")]
    public async Task<IActionResult> GetShortUrl(string url)
    {
        var shortUrl = await _shortUrlService.GetShortUrlAsync(url);
        if (shortUrl == null)
        {
            return NotFound("No available short URLs.");
        }

        return Ok(shortUrl);
    }

    [HttpGet("get-long-url/{shortUrlCode}")]
    public async Task<IActionResult> GetLongUrl(string shortUrlCode)
    {
        var longUrl = await _shortUrlService.GetLongUrlAsync(shortUrlCode);
        if (longUrl == null)
        {
            return NotFound("Short URL not found.");
        }

        return Ok(longUrl);
    }
}
