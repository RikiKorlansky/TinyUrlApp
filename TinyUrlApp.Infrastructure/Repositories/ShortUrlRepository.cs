using Microsoft.EntityFrameworkCore;
using TinyUrlApp.Domain.Entities;
using TinyUrlApp.Domain.Interfaces;

namespace TinyUrlApp.Infrastructure.Repositories;

public class ShortUrlRepository : IShortUrlRepository
{
    private readonly TinyUrlDbContext _context;

    public ShortUrlRepository(TinyUrlDbContext context)
    {
        _context = context;
    }

    public async Task<ShortUrl?> GetByShortCodeAsync(string shortCode)
    {
        return await _context.ShortUrls.FirstOrDefaultAsync(s => s.ShortUrlCode == shortCode);
    }

    public async Task AddAsync(ShortUrl shortUrl)
    {
        await _context.ShortUrls.AddAsync(shortUrl);
        await _context.SaveChangesAsync();
    }
}
