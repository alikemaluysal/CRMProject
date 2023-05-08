using FluentValidation;

namespace Application.Features.OfferStatus.Commands.Update;

public class UpdateOfferStatusCommandValidator : AbstractValidator<UpdateOfferStatusCommand>
{
    public UpdateOfferStatusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}