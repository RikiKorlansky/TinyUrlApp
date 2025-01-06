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
}
