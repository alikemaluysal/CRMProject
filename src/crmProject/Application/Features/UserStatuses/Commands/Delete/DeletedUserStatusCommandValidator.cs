using FluentValidation;

namespace Application.Features.UserStatuses.Commands.Delete;

public class DeleteUserStatusCommandValidator : AbstractValidator<DeleteUserStatusCommand>
{
    public DeleteUserStatusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}