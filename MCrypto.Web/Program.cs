using MCrypto.Core.Interfaces;
using MCrypto.Infrastructure.API;
using MCrypto.Infrastructure.Redis;
using StackExchange.Redis;
using MCrypto.Applicaton.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



// «÷«›Â ò—œ‰ RedisCache »Â DI
builder.Services.AddSingleton<RedisCache>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetSection("Redis:ConnectionString").Value;
    return new RedisCache(connectionString);
});

builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost"));
builder.Services.AddScoped<ICryptoCurrencyRepository, CryptoCurrencyService>();
builder.Services.AddScoped<CryptoCurrencyService>();
builder.Services.AddHttpClient<CryptocurrencyApiClient>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


