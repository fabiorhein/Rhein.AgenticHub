using Rhein.AgenticHub.Domain.Entities;

namespace Rhein.AgenticHub.Domain.Repositories;

public interface IAgentRepository
{
    Task<Agent?> GetByIdAsync(Guid id,  CancellationToken cancellationToken = default);
    Task AddAsync(Agent agent, CancellationToken cancellationToken = default);
    Task UpdateAsync(Agent agent, CancellationToken cancellationToken = default);
}