using Application.Features.OfferStatuses.Rules;
using Application.Features.RequestStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RequestStatuses.Commands.Create;

public class CreateRequestStatusCommand : IRequest<CreatedRequestStatusResponse>
{
    public string Name { get; set; }

    public class CreateRequestStatusCommandHandler : IRequestHandler<CreateRequestStatusCommand, CreatedRequestStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestStatusRepository _requestStatusRepository;
        private readonly RequestStatusBusinessRules _requestStatusBusinessRules;

        public CreateRequestStatusCommandHandler(IMapper mapper, IRequestStatusRepository requestStatusRepository,
                                         RequestStatusBusinessRules requestStatusBusinessRules)
        {
            _mapper = mapper;
            _requestStatusRepository = requestStatusRepository;
            _requestStatusBusinessRules = requestStatusBusinessRules;
        }

        public async Task<CreatedRequestStatusResponse> Handle(CreateRequestStatusCommand request, CancellationToken cancellationToken)
        {

            await _requestStatusBusinessRules.RequestStatusNameShouldNotExistWhenCreating(request.Name);


            RequestStatus requestStatus = _mapper.Map<RequestStatus>(request);

            await _requestStatusRepository.AddAsync(requestStatus);

            CreatedRequestStatusResponse response = _mapper.Map<CreatedRequestStatusResponse>(requestStatus);
            return response;
        }
    }
}