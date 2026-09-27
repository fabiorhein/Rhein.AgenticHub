using MediatR;
using Rhein.AgenticHub.Domain.Entities;
using Rhein.AgenticHub.Domain.Repositories;

namespace Rhein.AgenticHub.Application.Features.Agents.Commands.UpdateAgent;

public class UpdateAgentCommandHandler : IRequestHandler<UpdateAgentCommand, bool>
{
    private readonly IAgentRepository _agentRepository;

    public UpdateAgentCommandHandler(IAgentRepository agentRepository)
    {
        _agentRepository = agentRepository;
    }

    public async Task<bool> Handle(UpdateAgentCommand request, CancellationToken cancellationToken)
    {
        var agent = await _agentRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (agent == null)
            throw new Exception($"The agent with id {request.Id} was not found.");
        
        agent.UpdateName(request.Name);
        
        await _agentRepository.UpdateAsync(agent, cancellationToken);
        return true;
    }
}