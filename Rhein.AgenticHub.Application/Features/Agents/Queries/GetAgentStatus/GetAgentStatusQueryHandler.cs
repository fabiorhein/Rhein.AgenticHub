using MediatR;

namespace Rhein.AgenticHub.Application.Features.Agents.Queries.GetAgentStatus;

public class GetAgentStatusQueryHandler : IRequestHandler<GetAgentStatusQuery, AgentStatusViewModel?>
{
    private readonly IAgentQueries _agentQueries;

    public GetAgentStatusQueryHandler(IAgentQueries agentQueries)
    {
        _agentQueries = agentQueries;
    }

    public async Task<AgentStatusViewModel?> Handle(GetAgentStatusQuery request, CancellationToken cancellationToken)
    {
        return await _agentQueries.GetAgentStatusAsync(request.AgentId, cancellationToken);
    }
}