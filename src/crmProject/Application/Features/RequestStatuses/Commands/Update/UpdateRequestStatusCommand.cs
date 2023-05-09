using Application.Features.RequestStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RequestStatuses.Commands.Update;

public class UpdateRequestStatusCommand : IRequest<UpdatedRequestStatusResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateRequestStatusCommandHandler : IRequestHandler<UpdateRequestStatusCommand, UpdatedRequestStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestStatusRepository _requestStatusRepository;
        private readonly RequestStatusBusinessRules _requestStatusBusinessRules;

        public UpdateRequestStatusCommandHandler(IMapper mapper, IRequestStatusRepository requestStatusRepository,
                                         RequestStatusBusinessRules requestStatusBusinessRules)
        {
            _mapper = mapper;
            _requestStatusRepository = requestStatusRepository;
            _requestStatusBusinessRules = requestStatusBusinessRules;
        }

        public async Task<UpdatedRequestStatusResponse> Handle(UpdateRequestStatusCommand request, CancellationToken cancellationToken)
        {
            RequestStatus? requestStatus = await _requestStatusRepository.GetAsync(rs => rs.Id == request.Id, cancellationToken: cancellationToken);
            await _requestStatusBusinessRules.RequestStatusShouldExistWhenSelected(requestStatus);
            requestStatus = _mapper.Map(request, requestStatus);

            await _requestStatusRepository.UpdateAsync(requestStatus);

            UpdatedRequestStatusResponse response = _mapper.Map<UpdatedRequestStatusResponse>(requestStatus);
            return response;
        }
    }
}