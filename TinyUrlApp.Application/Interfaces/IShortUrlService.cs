public interface IShortUrlService
{
    Task GenerateSequentialShortUrlsAsync(int batchSize);
}
