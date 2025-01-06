using Microsoft.EntityFrameworkCore;
using TinyUrlApp.Domain.Entities;

namespace TinyUrlApp.Infrastructure
{
    public class TinyUrlDbContext : DbContext
    {
        public TinyUrlDbContext(DbContextOptions<TinyUrlDbContext> options) : base(options) { }

        // DbSet לטבלה UrlPools
        public DbSet<UrlPool> UrlPools { get; set; }
        public DbSet<ShortUrl> ShortUrls { get; set; }

    }

    public class UrlPool
    {
        public Guid Id { get; set; }
        public string ShortUrlCode { get; set; } = null!;
        public string? LongUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsUsed { get; set; } = false;
    }
    

}
