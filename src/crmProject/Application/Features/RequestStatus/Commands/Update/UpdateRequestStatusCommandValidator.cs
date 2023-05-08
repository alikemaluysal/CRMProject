using FluentValidation;

namespace Application.Features.RequestStatus.Commands.Update;

public class UpdateRequestStatusCommandValidator : AbstractValidator<UpdateRequestStatusCommand>
{
    public UpdateRequestStatusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}