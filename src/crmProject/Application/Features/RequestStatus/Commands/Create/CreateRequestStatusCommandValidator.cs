using FluentValidation;

namespace Application.Features.RequestStatus.Commands.Create;

public class CreateRequestStatusCommandValidator : AbstractValidator<CreateRequestStatusCommand>
{
    public CreateRequestStatusCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}