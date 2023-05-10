using Application.Features.Genders.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Genders.Rules;

public class GenderBusinessRules : BaseBusinessRules
{
    private readonly IGenderRepository _genderRepository;

    public GenderBusinessRules(IGenderRepository genderRepository)
    {
        _genderRepository = genderRepository;
    }

    public Task GenderShouldExistWhenSelected(Gender? gender)
    {
        if (gender == null)
            throw new BusinessException(GendersBusinessMessages.GenderNotExists);
        return Task.CompletedTask;
    }

    public async Task GenderIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Gender? gender = await _genderRepository.GetAsync(
            predicate: g => g.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GenderShouldExistWhenSelected(gender);
    }

    public async Task GenderNameShouldNotExistWhenCreating(string name)
    {
        Gender? result = await _genderRepository.GetAsync(x => x.Name.ToLower() == name.ToLower());
        if (result != null)
            throw new BusinessException(GendersBusinessMessages.GenderNameExists);
    }

    public async Task GenderNameShouldNotExistWhenUpdating(Gender gender)
    {
        Gender? result = await _genderRepository.GetAsync(x => x.Id != gender.Id && x.Name.ToLower() == gender.Name.ToLower());
        if (result != null)
            throw new BusinessException(GendersBusinessMessages.GenderNameExists);
    }
}