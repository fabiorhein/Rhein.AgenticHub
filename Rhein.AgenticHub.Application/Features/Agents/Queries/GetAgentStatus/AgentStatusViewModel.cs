namespace Rhein.AgenticHub.Application.Features.Agents.Queries.GetAgentStatus;

public record AgentStatusViewModel(
    Guid Id, 
    string Name, 
    int TotalPendingEvents, 
    string HealthStatus
);