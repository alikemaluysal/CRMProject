using Application.Features.UserStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserStatuses.Commands.Update;

public class UpdateUserStatusCommand : IRequest<UpdatedUserStatusResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateUserStatusCommandHandler : IRequestHandler<UpdateUserStatusCommand, UpdatedUserStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserStatusRepository _userStatusRepository;
        private readonly UserStatusBusinessRules _userStatusBusinessRules;

        public UpdateUserStatusCommandHandler(IMapper mapper, IUserStatusRepository userStatusRepository,
                                         UserStatusBusinessRules userStatusBusinessRules)
        {
            _mapper = mapper;
            _userStatusRepository = userStatusRepository;
            _userStatusBusinessRules = userStatusBusinessRules;
        }

        public async Task<UpdatedUserStatusResponse> Handle(UpdateUserStatusCommand request, CancellationToken cancellationToken)
        {
            UserStatus? userStatus = await _userStatusRepository.GetAsync(us => us.Id == request.Id, cancellationToken: cancellationToken);
            await _userStatusBusinessRules.UserStatusShouldExistWhenSelected(userStatus);
            userStatus = _mapper.Map(request, userStatus);

            await _userStatusRepository.UpdateAsync(userStatus);

            UpdatedUserStatusResponse response = _mapper.Map<UpdatedUserStatusResponse>(userStatus);
            return response;
        }
    }
}