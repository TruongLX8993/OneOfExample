// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using OneOfExample;

var serviceCollection = new ServiceCollection();
serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
serviceCollection.AddScoped<IProductRepository, ProductRepository>();
serviceCollection.AddScoped<ProductService>();

var serviceProvider = serviceCollection.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();
var scopeProvider = scope.ServiceProvider;
var productService = scopeProvider.GetService<ProductService>();
productService.CreateProduct("Product A", "pa", "123");
var oneOfGetById = productService.GetById(1);
var result = oneOfGetById.Match(dto => new Result() { Data = dto },
    _ => new Result() { Error = "Not found product with id" });
Console.WriteLine(JsonSerializer.Serialize(result));

oneOfGetById = productService.GetById(2);
result = oneOfGetById.Match(dto => new Result() { Data = dto },
    _ => new Result() { Error = "Not found product with id" });

Console.WriteLine(JsonSerializer.Serialize(result));