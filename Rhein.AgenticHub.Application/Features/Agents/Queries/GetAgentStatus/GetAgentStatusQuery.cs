using MediatR;

namespace Rhein.AgenticHub.Application.Features.Agents.Queries.GetAgentStatus;
public record GetAgentStatusQuery(Guid AgentId) : IRequest<AgentStatusViewModel?>;