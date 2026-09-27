using MediatR;

namespace Rhein.AgenticHub.Application.Features.Agents.Commands.UpdateAgent;
public record UpdateAgentCommand(Guid Id, string Name) : IRequest<bool>;
