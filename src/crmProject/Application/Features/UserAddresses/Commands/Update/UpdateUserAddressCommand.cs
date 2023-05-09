using Application.Features.UserAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.UserAddresses.Commands.Update;

public class UpdateUserAddressCommand : IRequest<UpdatedUserAddressResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
    public AddressTypeEnum AddressType { get; set; }

    public class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommand, UpdatedUserAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly UserAddressBusinessRules _userAddressBusinessRules;

        public UpdateUserAddressCommandHandler(IMapper mapper, IUserAddressRepository userAddressRepository,
                                         UserAddressBusinessRules userAddressBusinessRules)
        {
            _mapper = mapper;
            _userAddressRepository = userAddressRepository;
            _userAddressBusinessRules = userAddressBusinessRules;
        }

        public async Task<UpdatedUserAddressResponse> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
        {
            UserAddress? userAddress = await _userAddressRepository.GetAsync(ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _userAddressBusinessRules.UserAddressShouldExistWhenSelected(userAddress);
            userAddress = _mapper.Map(request, userAddress);

            await _userAddressRepository.UpdateAsync(userAddress);

            UpdatedUserAddressResponse response = _mapper.Map<UpdatedUserAddressResponse>(userAddress);
            return response;
        }
    }
}