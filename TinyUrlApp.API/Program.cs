using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TinyUrlApp.Domain.Interfaces;
using TinyUrlApp.Infrastructure;
using TinyUrlApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TinyUrlDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IShortUrlRepository, ShortUrlRepository>();
builder.Services.AddScoped<IShortUrlService, ShortUrlService>();

builder.Services.AddScoped<ShortUrlService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TinyUrl API",
        Version = "v1",
        Description = "API for managing TinyUrl URLs"
    });
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TinyUrl API v1");
    });
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
