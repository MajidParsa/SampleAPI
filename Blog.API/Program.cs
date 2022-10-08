using Blog.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.InitializeAutoMapper();
builder.Services.AddCustomSwagger();
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseCustomSwaggerUiExceptionHandler();
app.UseAuthorization();
app.MapControllers();

app.Run();
