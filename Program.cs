var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/",() =>
{
    return "API Panaderia funcionando";
});

app.MapGet("/api/panaderia",() =>
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
            nombre="Pan Chino",
        }
    });
});


app.Run();