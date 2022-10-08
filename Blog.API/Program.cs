using System.Reflection;
using Blog.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.InitializeAutoMapper();
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
