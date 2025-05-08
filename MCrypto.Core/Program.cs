using MCrypto.Core.Interfaces;
using MCrypto.Core.Models;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.Run();
