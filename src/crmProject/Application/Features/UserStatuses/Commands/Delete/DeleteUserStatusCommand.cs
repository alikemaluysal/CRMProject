using Application.Features.UserStatuses.Constants;
using Application.Features.UserStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserStatuses.Commands.Delete;

public class DeleteUserStatusCommand : IRequest<DeletedUserStatusResponse>
{
    public Guid Id { get; set; }

    public class DeleteUserStatusCommandHandler : IRequestHandler<DeleteUserStatusCommand, DeletedUserStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserStatusRepository _userStatusRepository;
        private readonly UserStatusBusinessRules _userStatusBusinessRules;

        public DeleteUserStatusCommandHandler(IMapper mapper, IUserStatusRepository userStatusRepository,
                                         UserStatusBusinessRules userStatusBusinessRules)
        {
            _mapper = mapper;
            _userStatusRepository = userStatusRepository;
            _userStatusBusinessRules = userStatusBusinessRules;
        }

        public async Task<DeletedUserStatusResponse> Handle(DeleteUserStatusCommand request, CancellationToken cancellationToken)
        {
            UserStatus? userStatus = await _userStatusRepository.GetAsync(us => us.Id == request.Id, cancellationToken: cancellationToken);
            await _userStatusBusinessRules.UserStatusShouldExistWhenSelected(userStatus);

            await _userStatusRepository.DeleteAsync(userStatus!);

            DeletedUserStatusResponse response = _mapper.Map<DeletedUserStatusResponse>(userStatus);
            return response;
        }
    }
}