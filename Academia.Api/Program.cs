using Academia.Application.Services;
using Academia.Data.Postgres.Context;
using Academia.Data.Postgres.Repository;
using Academia.Data.Repository;
using Academia.Data.Rest.Repository;
using Academia.Domain.Interfaces.Postgres;
using Academia.Domain.Interfaces.Repository;
using Academia.Domain.Interfaces.Rest;
using Academia.Domain.Interfaces.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabasePostGres")));

builder.Services.AddCors();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAcademiaService, AcademiaService>();
builder.Services.AddTransient<IAparelhoService, Aparelhoservice>();
builder.Services.AddTransient<IEnderecoRepository,  EnderecoRepository>();
builder.Services.AddTransient<IEnderecoService, EnderecoService>();
builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();
builder.Services.AddTransient<IPessoaService, PessoaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(opcoes => opcoes.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
