using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Northwind.Core.Interfaces;
using Northwind.Infrastructure;
using Northwind.Infrastructure.Repositories;
using Northwind.Services;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NorthwindContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnection"));
});

//Registering services
builder.Services.AddTransient<ICategoryService, CategoriesService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ISupplierService, SupplierService>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddAutoMapper(Assembly.Load("Northwind.Core"));

//Registering repositories
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Northwind Web API",
        Description = "An ASP.NET Core Web API using Onion Architecture"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlFilenameInfrastructure = $"{Assembly.Load("Northwind.Infrastructure").GetName().Name}.xml";
    var xmlFilenameCore = $"{Assembly.Load("Northwind.Core").GetName().Name}.xml";

    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilenameInfrastructure));
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilenameCore));
    options.EnableAnnotations();

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocExpansion(DocExpansion.None);
        options.DisplayRequestDuration();
        options.DefaultModelRendering(ModelRendering.Model);

        options.EnableFilter();
    });
}

app.UseReDoc(options =>
{
    options.DocumentTitle = "South West Traders Order Management API";
    options.SpecUrl = "/swagger/v1/swagger.json";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
