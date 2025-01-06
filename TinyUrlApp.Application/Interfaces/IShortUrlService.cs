public interface IShortUrlService
{
    Task GenerateSequentialShortUrlsAsync(int batchSize);
    Task<string?> GetShortUrlAsync(string url);
    Task<string?> GetLongUrlAsync(string shortUrlCode);
}
