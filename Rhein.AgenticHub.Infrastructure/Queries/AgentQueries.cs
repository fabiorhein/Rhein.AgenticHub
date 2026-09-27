using Microsoft.EntityFrameworkCore;
using Rhein.AgenticHub.Application.Features.Agents.Queries.GetAgentStatus;
using Rhein.AgenticHub.Infrastructure.Persistence;

namespace Rhein.AgenticHub.Infrastructure.Queries;

public class AgentQueries : IAgentQueries
{
    private readonly AgenticHubDbContext _dbContext;

    public AgentQueries(AgenticHubDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AgentStatusViewModel?> GetAgentStatusAsync(Guid agentId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Agents
            .AsNoTracking()
            .Where(a => a.Id == agentId)
            .Select(a => new AgentStatusViewModel(
                a.Id,
                a.Name,
                a.AssignedEvents.Count(e => e.Status == "Pending"),
                a.AssignedEvents.Count > 4 ? "Busy" : "Available"
            ))
            .FirstOrDefaultAsync(cancellationToken);
    }
}