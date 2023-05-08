using Application.Features.UserPhones.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.UserPhones.Commands.Create;

public class CreateUserPhoneCommand : IRequest<CreatedUserPhoneResponse>
{
    public int UserId { get; set; }
    public string? PhoneNumber { get; set; }
    public PhoneTypeEnum PhoneType { get; set; }

    public class CreateUserPhoneCommandHandler : IRequestHandler<CreateUserPhoneCommand, CreatedUserPhoneResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPhoneRepository _userPhoneRepository;
        private readonly UserPhoneBusinessRules _userPhoneBusinessRules;

        public CreateUserPhoneCommandHandler(IMapper mapper, IUserPhoneRepository userPhoneRepository,
                                         UserPhoneBusinessRules userPhoneBusinessRules)
        {
            _mapper = mapper;
            _userPhoneRepository = userPhoneRepository;
            _userPhoneBusinessRules = userPhoneBusinessRules;
        }

        public async Task<CreatedUserPhoneResponse> Handle(CreateUserPhoneCommand request, CancellationToken cancellationToken)
        {
            UserPhone userPhone = _mapper.Map<UserPhone>(request);

            await _userPhoneRepository.AddAsync(userPhone);

            CreatedUserPhoneResponse response = _mapper.Map<CreatedUserPhoneResponse>(userPhone);
            return response;
        }
    }
}