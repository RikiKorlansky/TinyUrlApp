namespace TinyUrlApp.Domain.Entities;

public class ShortUrl
{
    public Guid Id { get; set; }
    public string ShortUrlCode { get; set; } = null!;
    public string? LongUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsUsed { get; set; } = false;
    
    private ShortUrl() { } 

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
