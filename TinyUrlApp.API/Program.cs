using Microsoft.EntityFrameworkCore;
using TinyUrlApp.Application.Services;
using TinyUrlApp.Domain.Interfaces;
using TinyUrlApp.Infrastructure;
using TinyUrlApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TinyUrlDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IShortUrlRepository, ShortUrlRepository>();
builder.Services.AddScoped<ShortUrlService>();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();
