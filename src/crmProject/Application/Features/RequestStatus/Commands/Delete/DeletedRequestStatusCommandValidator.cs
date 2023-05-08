using FluentValidation;

namespace Application.Features.RequestStatus.Commands.Delete;

public class DeleteRequestStatusCommandValidator : AbstractValidator<DeleteRequestStatusCommand>
{
    public DeleteRequestStatusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}