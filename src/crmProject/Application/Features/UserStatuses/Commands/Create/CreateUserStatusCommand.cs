using Application.Features.UserStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserStatuses.Commands.Create;

public class CreateUserStatusCommand : IRequest<CreatedUserStatusResponse>
{
    public string Name { get; set; }

    public class CreateUserStatusCommandHandler : IRequestHandler<CreateUserStatusCommand, CreatedUserStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserStatusRepository _userStatusRepository;
        private readonly UserStatusBusinessRules _userStatusBusinessRules;

        public CreateUserStatusCommandHandler(IMapper mapper, IUserStatusRepository userStatusRepository,
                                         UserStatusBusinessRules userStatusBusinessRules)
        {
            _mapper = mapper;
            _userStatusRepository = userStatusRepository;
            _userStatusBusinessRules = userStatusBusinessRules;
        }

        public async Task<CreatedUserStatusResponse> Handle(CreateUserStatusCommand request, CancellationToken cancellationToken)
        {
            UserStatus userStatus = _mapper.Map<UserStatus>(request);

            await _userStatusRepository.AddAsync(userStatus);

            CreatedUserStatusResponse response = _mapper.Map<CreatedUserStatusResponse>(userStatus);
            return response;
        }
    }
}