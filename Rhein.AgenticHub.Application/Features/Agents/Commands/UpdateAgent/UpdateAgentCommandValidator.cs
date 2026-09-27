using FluentValidation;

namespace Rhein.AgenticHub.Application.Features.Agents.Commands.UpdateAgent;

public class UpdateAgentCommandValidator :  AbstractValidator<UpdateAgentCommand>
{
    public UpdateAgentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The agent ID is required.");
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The name of the agent is required")
            .MinimumLength(3).WithMessage("The name needs to be at least 3 characters long");
    }
}