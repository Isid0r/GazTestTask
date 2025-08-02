using GazTestTask.Application.Services;
using GazTestTask.Domain.Interfaces.Repositories;
using GazTestTask.Infrastructure.Repositories;
using GazTestTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using GazTestTask.Application.Mapping;
using GazTestTask.Application.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

builder.Services.AddAutoMapper(cfg => {}, typeof(MappingProfile));

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
