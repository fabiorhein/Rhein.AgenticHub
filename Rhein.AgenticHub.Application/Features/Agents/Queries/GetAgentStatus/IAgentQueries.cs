namespace Rhein.AgenticHub.Application.Features.Agents.Queries.GetAgentStatus;

public interface IAgentQueries
{
    Task<AgentStatusViewModel?> GetAgentStatusAsync(Guid agentId, CancellationToken cancellationToken = default);
}