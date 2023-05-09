using Application.Features.UserPhones.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.UserPhones.Commands.Update;

public class UpdateUserPhoneCommand : IRequest<UpdatedUserPhoneResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? PhoneNumber { get; set; }
    public PhoneTypeEnum PhoneType { get; set; }

    public class UpdateUserPhoneCommandHandler : IRequestHandler<UpdateUserPhoneCommand, UpdatedUserPhoneResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPhoneRepository _userPhoneRepository;
        private readonly UserPhoneBusinessRules _userPhoneBusinessRules;

        public UpdateUserPhoneCommandHandler(IMapper mapper, IUserPhoneRepository userPhoneRepository,
                                         UserPhoneBusinessRules userPhoneBusinessRules)
        {
            _mapper = mapper;
            _userPhoneRepository = userPhoneRepository;
            _userPhoneBusinessRules = userPhoneBusinessRules;
        }

        public async Task<UpdatedUserPhoneResponse> Handle(UpdateUserPhoneCommand request, CancellationToken cancellationToken)
        {
            UserPhone? userPhone = await _userPhoneRepository.GetAsync(up => up.Id == request.Id, cancellationToken: cancellationToken);
            await _userPhoneBusinessRules.UserPhoneShouldExistWhenSelected(userPhone);
            userPhone = _mapper.Map(request, userPhone);

            await _userPhoneRepository.UpdateAsync(userPhone);

            UpdatedUserPhoneResponse response = _mapper.Map<UpdatedUserPhoneResponse>(userPhone);
            return response;
        }
    }
}