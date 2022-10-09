using System.Text.Json.Serialization;
using Blog.API.Configuration;
using Blog.Application.Configuration;
using Blog.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services
    .InitializeAutoMapper()
    .AddCustomSwagger()
    .AddMediatR()
    .AddInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseCustomSwaggerUiExceptionHandler();
app.UseAuthorization();
app.MapControllers();

app.Run();
