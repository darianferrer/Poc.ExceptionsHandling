using Poc.ExceptionsHandling.Host.Middlewares;
using Poc.ExceptionsHandling.Host.Repositories;
using Poc.ExceptionsHandling.Host.Services;
using Poc.ExceptionsHandling.Host.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductValidator, ProductValidatorWithResult>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService,ProductService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseMiddleware<ExceptionsMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
