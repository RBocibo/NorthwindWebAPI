using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Northwind.Core.Interfaces;
using Northwind.Infrastructure;
using Northwind.Infrastructure.Repositories;
using Northwind.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NorthwindContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnection"));
});

//Registering services
builder.Services.AddTransient<ICategoryService, CategoriesService>();
builder.Services.AddAutoMapper(Assembly.Load("Northwind.Core"));

//Registering repositories
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
