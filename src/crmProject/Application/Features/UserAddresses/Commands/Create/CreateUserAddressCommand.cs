using Application.Features.UserAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.UserAddresses.Commands.Create;

public class CreateUserAddressCommand : IRequest<CreatedUserAddressResponse>
{
    public int UserId { get; set; }
    public string Description { get; set; }
    public AddressTypeEnum AddressType { get; set; }

    public class CreateUserAddressCommandHandler : IRequestHandler<CreateUserAddressCommand, CreatedUserAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly UserAddressBusinessRules _userAddressBusinessRules;

        public CreateUserAddressCommandHandler(IMapper mapper, IUserAddressRepository userAddressRepository,
                                         UserAddressBusinessRules userAddressBusinessRules)
        {
            _mapper = mapper;
            _userAddressRepository = userAddressRepository;
            _userAddressBusinessRules = userAddressBusinessRules;
        }

        public async Task<CreatedUserAddressResponse> Handle(CreateUserAddressCommand request, CancellationToken cancellationToken)
        {
            UserAddress userAddress = _mapper.Map<UserAddress>(request);

            await _userAddressRepository.AddAsync(userAddress);

            CreatedUserAddressResponse response = _mapper.Map<CreatedUserAddressResponse>(userAddress);
            return response;
        }
    }
}