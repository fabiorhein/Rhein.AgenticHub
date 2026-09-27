using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rhein.AgenticHub.Application.Behaviors;
using Rhein.AgenticHub.Application.Features.Agents.Commands.UpdateAgent;
using Rhein.AgenticHub.Application.Features.Agents.Queries.GetAgentStatus;
using Rhein.AgenticHub.Infrastructure.Persistence;
using Rhein.AgenticHub.Infrastructure.Queries;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURAÇÃO DE SERVIÇOS (Injeção de Dependência) ---

// Mantemos o OpenAPI para gerar a documentação da nossa API de Agentes
builder.Services.AddOpenApi();

// Registra o MediatR e os Behaviors (O nosso pipeline)
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(UpdateAgentCommand).Assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

// Registra todos os validadores do FluentValidation automaticamente
builder.Services.AddValidatorsFromAssembly(typeof(UpdateAgentCommandValidator).Assembly);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? "Host=localhost;Database=AgenticHubDb;Username=postgres;Password=suasenha";
builder.Services.AddDbContext<AgenticHubDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IAgentQueries, AgentQueries>();

var app = builder.Build();

// --- 2. CONFIGURAÇÃO DO PIPELINE HTTP ---

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Dica para o futuro: Aqui é onde adicionaríamos o Swagger UI ou Scalar
}

app.UseHttpsRedirection();

// --- 3. NOSSOS ENDPOINTS (Minimal APIs) ---

// Adeus WeatherForecast, olá AgenticHub!
app.MapPut("/api/agents", async (UpdateAgentCommand command, IMediator mediator) =>
    {
        // A API não valida nada, não tem regra de negócio, não acessa banco.
        // Ela só entrega o envelope para o carteiro (MediatR).
        var result = await mediator.Send(command);
    
        return Results.Ok(result);
    })
    .WithName("UpdateAgent");

// Mantém o servidor rodando e escutando requisições
app.Run();