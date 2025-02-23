using MassTransit;
using Service.Financeiro.Lancamento.Application.Applications.v1.AdicionarLancamento;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
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

builder.Services.AddMassTransitHostedService();


builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();