using Microsoft.OpenApi.Models;
using PizzaStore.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
  var info = new OpenApiInfo {
    Title = "Todo API",
    Description = "Keep track of your tasks",
    Version = "v1"
  };

  c.SwaggerDoc("v1", info);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1"));

app.MapGet("/", () => "Hello World!");
app.MapGet("/pizzas", () => PizzaDb.GetPizzas());
app.MapGet("/pizzas/{id}", (int id) => PizzaDb.GetPizza(id));
app.MapPost("/pizzas", (Pizza pizza) => PizzaDb.CreatePizza(pizza));
app.MapPut("/pizzas", (Pizza pizza) => PizzaDb.UpdatePizza(pizza));
app.MapDelete("/pizzas/{id}", (int id) => PizzaDb.RemovePizza(id));

app.Run();
