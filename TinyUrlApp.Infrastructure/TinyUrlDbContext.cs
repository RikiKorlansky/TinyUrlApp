using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TinyUrlApp.Domain.Entities;

namespace TinyUrlApp.Infrastructure;

public class TinyUrlDbContext : DbContext
{
    public TinyUrlDbContext(DbContextOptions<TinyUrlDbContext> options) : base(options) { }
    public DbSet<ShortUrl> ShortUrls { get; set; }
}
