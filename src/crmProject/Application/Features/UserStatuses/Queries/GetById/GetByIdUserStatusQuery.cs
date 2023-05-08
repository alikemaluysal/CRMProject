using Application.Features.UserStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserStatuses.Queries.GetById;

public class GetByIdUserStatusQuery : IRequest<GetByIdUserStatusResponse>
{
    public Guid Id { get; set; }

    public class GetByIdUserStatusQueryHandler : IRequestHandler<GetByIdUserStatusQuery, GetByIdUserStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserStatusRepository _userStatusRepository;
        private readonly UserStatusBusinessRules _userStatusBusinessRules;

        public GetByIdUserStatusQueryHandler(IMapper mapper, IUserStatusRepository userStatusRepository, UserStatusBusinessRules userStatusBusinessRules)
        {
            _mapper = mapper;
            _userStatusRepository = userStatusRepository;
            _userStatusBusinessRules = userStatusBusinessRules;
        }

        public async Task<GetByIdUserStatusResponse> Handle(GetByIdUserStatusQuery request, CancellationToken cancellationToken)
        {
            UserStatus? userStatus = await _userStatusRepository.GetAsync(predicate: us => us.Id == request.Id, cancellationToken: cancellationToken);
            await _userStatusBusinessRules.UserStatusShouldExistWhenSelected(userStatus);

            GetByIdUserStatusResponse response = _mapper.Map<GetByIdUserStatusResponse>(userStatus);
            return response;
        }
    }
}