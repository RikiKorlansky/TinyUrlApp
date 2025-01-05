using TinyUrlApp.Domain.Entities;
using TinyUrlApp.Domain.Interfaces;

namespace TinyUrlApp.Application.Services;

public class ShortUrlService
{
    private readonly IShortUrlRepository _repository;

    public ShortUrlService(IShortUrlRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> CreateShortUrlAsync(string longUrl)
    {
        var shortUrl = new ShortUrl(longUrl);
        await _repository.AddAsync(shortUrl);
        return shortUrl.ShortUrlCode;
    }

    public async Task<string?> GetLongUrlAsync(string shortCode)
    {
        var shortUrl = await _repository.GetByShortCodeAsync(shortCode);
        return shortUrl?.LongUrl;
    }
}
