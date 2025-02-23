using AutoMapper;
using ClosedXML.Parser;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Service.Financeiro.Lancamento.Application.Applications.v1.AdicionarLancamento;
using Service.Financeiro.Lancamento.Application.Profiles;
using Service.Financeiro.Lancamento.Persistence.Context;
using Service.Financeiro.Lancamento.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<LancamentoContext>(options => options.UseInMemoryDatabase("TestDatabase"));
builder.Services.AddControllers();
builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();
builder.Services.AddSingleton<IMapper>(sp =>
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile(new ApplicationProfile());
    });
    return config.CreateMapper();
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(AdicionarLancamentoCommandHandler).Assembly);
});

builder.Services.AddMassTransit(bus =>
{
    bus.UsingRabbitMq((ctx, busConfigurator) =>
    {
        busConfigurator.Host(configuration.GetConnectionString("RabbitMq"));
    });

});

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();