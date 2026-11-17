using System.ComponentModel;
using ElectronicsTest;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); //найди все запросы
builder.Services.AddSwaggerGen(); // сделай по запросам описание

var app = builder.Build();

app.MapSwagger(); //description in json
app.UseSwaggerUI();

var Products = new List<Phone>
{
    new Phone{ Id = 1, Name = "Айфон", Price = 1000},
    new Phone{ Id = 2, Name = "Самсунг", Price = 800},
    new Phone{ Id = 3, Name = "Реалми", Price = 600},

};
app.MapGet("/api/hello", () => "Hello world");

app.MapControllers();
app.MapGet("/api/products", () =>
{
    return Results.Ok(Products);   //Статус 200 (список телефонов)
});


app.MapGet("/api/products/{Id}", (int id) => {
    Phone? phone = Products.FirstOrDefault(p => p.Id == id);
    if (phone == null) return Results.NotFound();
    return Results.Ok(phone);
});
app.Run();