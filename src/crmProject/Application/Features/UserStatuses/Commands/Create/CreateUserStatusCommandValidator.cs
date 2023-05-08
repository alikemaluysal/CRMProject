using FluentValidation;

namespace Application.Features.UserStatuses.Commands.Create;

public class CreateUserStatusCommandValidator : AbstractValidator<CreateUserStatusCommand>
{
    public CreateUserStatusCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}