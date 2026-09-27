using MediatR;

namespace Rhein.AgenticHub.Application.Features.Agents.Commands.CreateAgent;

// IRequest<Guid> indica que, ao finalizar, esse comando devolverá o ID do novo Agente
public record CreateAgentCommand(string Name) : IRequest<Guid>;