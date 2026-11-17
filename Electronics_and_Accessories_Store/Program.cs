using System.ComponentModel;
using ElectronicsTest;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); //найди все запросы
builder.Services.AddSwaggerGen(); // сделай по запросам описание

var app = builder.Build();

app.MapSwagger(); //description in json
app.UseSwaggerUI();

app.MapGet("/api/hello", () => "Hello world");

app.MapControllers();




app.Run();