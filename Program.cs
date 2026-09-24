var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.MapGet("/", () =>
{
    return "API Panaderia funcionando";
});

app.MapGet("/api/panaderia", () =>
{
    return Results.Ok(new[]
    {
        new
        {
            id = 1,
            codigo = "P001",
            nombre = "Pan Frances"
        },
        new
        {
            id = 2,
            codigo = "P002",
            nombre = "Pan Chino"
        }
    });
});

var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";

app.Run($"http://0.0.0.0:{port}");
