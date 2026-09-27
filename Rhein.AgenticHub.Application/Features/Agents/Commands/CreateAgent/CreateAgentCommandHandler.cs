using MediatR;
using Rhein.AgenticHub.Domain.Entities;
using Rhein.AgenticHub.Domain.Repositories;

namespace Rhein.AgenticHub.Application.Features.Agents.Commands.CreateAgent;

public class CreateAgentCommandHandler : IRequestHandler<CreateAgentCommand, Guid>
{
    private readonly IAgentRepository _agentRepository;

    public CreateAgentCommandHandler(IAgentRepository agentRepository)
    {
        _agentRepository = agentRepository;
    }

    public async Task<Guid> Handle(CreateAgentCommand request, CancellationToken cancellationToken)
    {
        // 1. Instancia a Entidade de Domínio (As regras de negócio do construtor garantem a validade)
        var agent = new Agent(request.Name);

        // 2. Persiste via abstração
        await _agentRepository.AddAsync(agent, cancellationToken);
        
        // Em um cenário real com EF Core, você pode ter um UnitOfWork aqui: await _unitOfWork.CommitAsync();

        // 3. Retorna o resultado
        return agent.Id;
    }
}