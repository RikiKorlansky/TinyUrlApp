namespace TinyUrlApp.Domain.Entities;

public class ShortUrl
{
    public Guid Id { get; private set; }
    public string ShortUrlCode { get; private set; }
    public string LongUrl { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private ShortUrl() { } // דרוש ל-EF Core

    public ShortUrl(string longUrl)
    {
        Id = Guid.NewGuid();
        LongUrl = longUrl;
        ShortUrlCode = GenerateShortCode();
        CreatedAt = DateTime.UtcNow;
    }

    private string GenerateShortCode()
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 7).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
