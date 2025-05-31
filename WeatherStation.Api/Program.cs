using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApiDocument();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Serve your pre-generated OpenAPI JSON/YAML with Scalar
    app.UseOpenApi(settings =>
    {
        settings.Path = "/docs/openapi.json";
    });
    app.MapScalarApiReference(options =>
    {
        options.OpenApiRoutePattern = "/docs/openapi.json";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();