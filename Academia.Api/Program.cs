using Academia.Application.Services;
using Academia.Data.Postgres.Context;
using Academia.Data.Postgres.Repository;
using Academia.Data.Repository;
using Academia.Domain.Interfaces.Postgres;
using Academia.Domain.Interfaces.Repository;
using Academia.Domain.Interfaces.Service;
using Academia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using acdm = Academia.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabasePostGres")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IRepositoryBase<acdm.Academia>, RepositoryBase<acdm.Academia>>();
builder.Services.AddTransient<IAcademiaService, AcademiaService>();
builder.Services.AddTransient<IRepositoryBase<Aparelho>, RepositoryBase<Aparelho>>();
builder.Services.AddTransient<IAparelhoService, Aparelhoservice>();



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
