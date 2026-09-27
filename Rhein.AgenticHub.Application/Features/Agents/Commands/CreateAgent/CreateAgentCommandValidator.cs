using FluentValidation;

namespace Rhein.AgenticHub.Application.Features.Agents.Commands.CreateAgent;

public class CreateAgentCommandValidator : AbstractValidator<CreateAgentCommand>
{
    public CreateAgentCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The agent name is required.")
            .MinimumLength(3).WithMessage("The name needs to be at least 3 characters long.");
    }
}