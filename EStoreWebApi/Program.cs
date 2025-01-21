using EStoreWebApi.infrastructure;
using EStoreWebApi.IRepository;
using EStoreWebApi.Repository;
using EStoreWebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionSting = builder.Configuration.GetConnectionString("SqlConnection");

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(connectionSting);
});

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new DtoMapProfile());
});


builder.Services.AddTransient<ICustomerRepository,CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
