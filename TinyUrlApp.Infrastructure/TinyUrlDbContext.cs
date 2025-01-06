using Microsoft.EntityFrameworkCore;
using TinyUrlApp.Domain.Entities;

namespace TinyUrlApp.Infrastructure
{
    public class TinyUrlDbContext : DbContext
    {
        public TinyUrlDbContext(DbContextOptions<TinyUrlDbContext> options) : base(options) { }

        // DbSet לטבלה UrlPools
        public DbSet<UrlPool> UrlPools { get; set; }

    }

    
    

}
