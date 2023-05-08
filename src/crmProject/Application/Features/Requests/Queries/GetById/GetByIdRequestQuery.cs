using Application.Features.Requests.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Requests.Queries.GetById;

public class GetByIdRequestQuery : IRequest<GetByIdRequestResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRequestQueryHandler : IRequestHandler<GetByIdRequestQuery, GetByIdRequestResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _requestRepository;
        private readonly RequestBusinessRules _requestBusinessRules;

        public GetByIdRequestQueryHandler(IMapper mapper, IRequestRepository requestRepository, RequestBusinessRules requestBusinessRules)
        {
            _mapper = mapper;
            _requestRepository = requestRepository;
            _requestBusinessRules = requestBusinessRules;
        }

        public async Task<GetByIdRequestResponse> Handle(GetByIdRequestQuery request, CancellationToken cancellationToken)
        {
            Request? requestEntity = await _requestRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _requestBusinessRules.RequestShouldExistWhenSelected(requestEntity);

            GetByIdRequestResponse response = _mapper.Map<GetByIdRequestResponse>(requestEntity);
            return response;
        }
    }
}