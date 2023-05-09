using Application.Features.UserPhones.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.UserPhones.Rules;

public class UserPhoneBusinessRules : BaseBusinessRules
{
    private readonly IUserPhoneRepository _userPhoneRepository;

    public UserPhoneBusinessRules(IUserPhoneRepository userPhoneRepository)
    {
        _userPhoneRepository = userPhoneRepository;
    }

    public Task UserPhoneShouldExistWhenSelected(UserPhone? userPhone)
    {
        if (userPhone == null)
            throw new BusinessException(UserPhonesBusinessMessages.UserPhoneNotExists);
        return Task.CompletedTask;
    }

    public async Task UserPhoneIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        UserPhone? userPhone = await _userPhoneRepository.GetAsync(
            predicate: up => up.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserPhoneShouldExistWhenSelected(userPhone);
    }
}