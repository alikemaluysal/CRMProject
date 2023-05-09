using Application.Features.UserEmails.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.UserEmails.Rules;

public class UserEmailBusinessRules : BaseBusinessRules
{
    private readonly IUserEmailRepository _userEmailRepository;

    public UserEmailBusinessRules(IUserEmailRepository userEmailRepository)
    {
        _userEmailRepository = userEmailRepository;
    }

    public Task UserEmailShouldExistWhenSelected(UserEmail? userEmail)
    {
        if (userEmail == null)
            throw new BusinessException(UserEmailsBusinessMessages.UserEmailNotExists);
        return Task.CompletedTask;
    }

    public async Task UserEmailIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        UserEmail? userEmail = await _userEmailRepository.GetAsync(
            predicate: ue => ue.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserEmailShouldExistWhenSelected(userEmail);
    }
}