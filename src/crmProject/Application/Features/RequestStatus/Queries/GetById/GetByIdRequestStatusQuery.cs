using Application.Features.RequestStatus.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RequestStatus.Queries.GetById;

public class GetByIdRequestStatusQuery : IRequest<GetByIdRequestStatusResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRequestStatusQueryHandler : IRequestHandler<GetByIdRequestStatusQuery, GetByIdRequestStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestStatusRepository _requestStatusRepository;
        private readonly RequestStatusBusinessRules _requestStatusBusinessRules;

        public GetByIdRequestStatusQueryHandler(IMapper mapper, IRequestStatusRepository requestStatusRepository, RequestStatusBusinessRules requestStatusBusinessRules)
        {
            _mapper = mapper;
            _requestStatusRepository = requestStatusRepository;
            _requestStatusBusinessRules = requestStatusBusinessRules;
        }

        public async Task<GetByIdRequestStatusResponse> Handle(GetByIdRequestStatusQuery request, CancellationToken cancellationToken)
        {
            RequestStatus? requestStatus = await _requestStatusRepository.GetAsync(predicate: rs => rs.Id == request.Id, cancellationToken: cancellationToken);
            await _requestStatusBusinessRules.RequestStatusShouldExistWhenSelected(requestStatus);

            GetByIdRequestStatusResponse response = _mapper.Map<GetByIdRequestStatusResponse>(requestStatus);
            return response;
        }
    }
}