using Microsoft.EntityFrameworkCore;
using TinyUrlApp.Infrastructure;

public class ShortUrlService : IShortUrlService
{
    private readonly TinyUrlDbContext _context;
    private const string CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    public ShortUrlService(TinyUrlDbContext context)
    {
        _context = context;
    }

    public async Task GenerateSequentialShortUrlsAsync(int batchSize)
    {
        // get last url
        var lastShortUrl = await _context.UrlPools
            .OrderByDescending(u => u.ShortUrlCode)
            .Select(u => u.ShortUrlCode)
            .FirstOrDefaultAsync();

        // create new urls
        var startCode = string.IsNullOrEmpty(lastShortUrl) ? "AAAAAAA" : IncrementShortUrl(lastShortUrl);

        // create urls group
        var urls = Enumerable.Range(0, batchSize)
            .Select(i => new UrlPool
            {
                Id = Guid.NewGuid(),
                ShortUrlCode = IncrementShortUrl(startCode, i),
                LongUrl = string.Empty,
                CreatedAt = DateTime.UtcNow
            }).ToList();

        // insert urls to DB
        await _context.UrlPools.AddRangeAsync(urls);
        await _context.SaveChangesAsync();
    }

    private string IncrementShortUrl(string current, int incrementBy = 1)
    {
        var charArray = current.ToCharArray();
        var length = charArray.Length;
        var carry = incrementBy;

        for (var i = length - 1; i >= 0 && carry > 0; i--)
        {
            var index = CharSet.IndexOf(charArray[i]) + carry;
            charArray[i] = CharSet[index % CharSet.Length];
            carry = index / CharSet.Length;
        }

        if (carry > 0)
        {
            return new string(CharSet[0], 1) + new string(charArray);
        }

        return new string(charArray);
    }
}
