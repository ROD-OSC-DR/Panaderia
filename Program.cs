var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy( policity =>
            {
                policity
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
            }
        )
    }
)

var app = builder.Build();

app.UseCors()

app.MapGet("/",() =>
{
    return "API Panaderia funcionando";
});

app.MapGet("/api/panadera",() =>
{
    return Results.Ok(new[]
    {
        new{
            id=1,
            codigo="P001",
            nombre="Pan Frances",
        },
        new{
            id=2,
            codigo="P002",
            nombre="Pan chino",
        }
    });
});

var port = Environment.GetEnvironmentVariable("Port")??"10000",
app.Run($"http://0.0.0.0:(port)");
