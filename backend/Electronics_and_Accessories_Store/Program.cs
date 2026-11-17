var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer(); //найди все запросы
builder.Services.AddSwaggerGen(); // сделай по запросам описание


var app = builder.Build();


app.MapSwagger(); //описание в json
app.UseSwaggerUI();


app.MapGet("/", () =>
{
    return Results.Content("Hello World!", "text/plain");
});

app.Run();