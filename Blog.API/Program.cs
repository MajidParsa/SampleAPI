using Blog.API.Configuration;
using Blog.Application.Configuration;
using Blog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services
    .InitializeAutoMapper()
    .AddCustomSwagger()
    .AddServices()
    .AddInfrastructure();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseCustomSwaggerUiExceptionHandler();
app.UseAuthorization();
app.MapControllers();

app.Run();
