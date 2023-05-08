using Application.Features.Settings.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Settings.Rules;

public class SettingBusinessRules : BaseBusinessRules
{
    private readonly ISettingRepository _settingRepository;

    public SettingBusinessRules(ISettingRepository settingRepository)
    {
        _settingRepository = settingRepository;
    }

    public Task SettingShouldExistWhenSelected(Setting? setting)
    {
        if (setting == null)
            throw new BusinessException(SettingsBusinessMessages.SettingNotExists);
        return Task.CompletedTask;
    }

    public async Task SettingIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Setting? setting = await _settingRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SettingShouldExistWhenSelected(setting);
    }
}