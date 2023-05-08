using Application.Features.UserPhones.Constants;
using Application.Features.UserPhones.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserPhones.Commands.Delete;

public class DeleteUserPhoneCommand : IRequest<DeletedUserPhoneResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserPhoneCommandHandler : IRequestHandler<DeleteUserPhoneCommand, DeletedUserPhoneResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPhoneRepository _userPhoneRepository;
        private readonly UserPhoneBusinessRules _userPhoneBusinessRules;

        public DeleteUserPhoneCommandHandler(IMapper mapper, IUserPhoneRepository userPhoneRepository,
                                         UserPhoneBusinessRules userPhoneBusinessRules)
        {
            _mapper = mapper;
            _userPhoneRepository = userPhoneRepository;
            _userPhoneBusinessRules = userPhoneBusinessRules;
        }

        public async Task<DeletedUserPhoneResponse> Handle(DeleteUserPhoneCommand request, CancellationToken cancellationToken)
        {
            UserPhone? userPhone = await _userPhoneRepository.GetAsync(up => up.Id == request.Id, cancellationToken: cancellationToken);
            await _userPhoneBusinessRules.UserPhoneShouldExistWhenSelected(userPhone);

            await _userPhoneRepository.DeleteAsync(userPhone!);

            DeletedUserPhoneResponse response = _mapper.Map<DeletedUserPhoneResponse>(userPhone);
            return response;
        }
    }
}