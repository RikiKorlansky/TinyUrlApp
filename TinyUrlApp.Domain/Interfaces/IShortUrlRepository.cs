using TinyUrlApp.Domain.Entities;

namespace TinyUrlApp.Domain.Interfaces
{
    public interface IShortUrlRepository
    {
        Task<ShortUrl?> GetByShortCodeAsync(string shortCode);
        Task AddAsync(ShortUrl shortUrl);
    }
}
