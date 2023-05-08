using FluentValidation;

namespace Application.Features.OfferStatus.Commands.Create;

public class CreateOfferStatusCommandValidator : AbstractValidator<CreateOfferStatusCommand>
{
    public CreateOfferStatusCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}