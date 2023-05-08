using Application.Features.UserAddresses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.UserAddresses.Rules;

public class UserAddressBusinessRules : BaseBusinessRules
{
    private readonly IUserAddressRepository _userAddressRepository;

    public UserAddressBusinessRules(IUserAddressRepository userAddressRepository)
    {
        _userAddressRepository = userAddressRepository;
    }

    public Task UserAddressShouldExistWhenSelected(UserAddress? userAddress)
    {
        if (userAddress == null)
            throw new BusinessException(UserAddressesBusinessMessages.UserAddressNotExists);
        return Task.CompletedTask;
    }

    public async Task UserAddressIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserAddress? userAddress = await _userAddressRepository.GetAsync(
            predicate: ua => ua.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserAddressShouldExistWhenSelected(userAddress);
    }
}