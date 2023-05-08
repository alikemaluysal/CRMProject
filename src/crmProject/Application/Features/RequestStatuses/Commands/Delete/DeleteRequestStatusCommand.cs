using Application.Features.RequestStatuses.Constants;
using Application.Features.RequestStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RequestStatuses.Commands.Delete;

public class DeleteRequestStatusCommand : IRequest<DeletedRequestStatusResponse>
{
    public Guid Id { get; set; }

    public class DeleteRequestStatusCommandHandler : IRequestHandler<DeleteRequestStatusCommand, DeletedRequestStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestStatusRepository _requestStatusRepository;
        private readonly RequestStatusBusinessRules _requestStatusBusinessRules;

        public DeleteRequestStatusCommandHandler(IMapper mapper, IRequestStatusRepository requestStatusRepository,
                                         RequestStatusBusinessRules requestStatusBusinessRules)
        {
            _mapper = mapper;
            _requestStatusRepository = requestStatusRepository;
            _requestStatusBusinessRules = requestStatusBusinessRules;
        }

        public async Task<DeletedRequestStatusResponse> Handle(DeleteRequestStatusCommand request, CancellationToken cancellationToken)
        {
            RequestStatus? requestStatus = await _requestStatusRepository.GetAsync(rs => rs.Id == request.Id, cancellationToken: cancellationToken);
            await _requestStatusBusinessRules.RequestStatusShouldExistWhenSelected(requestStatus);

            await _requestStatusRepository.DeleteAsync(requestStatus!);

            DeletedRequestStatusResponse response = _mapper.Map<DeletedRequestStatusResponse>(requestStatus);
            return response;
        }
    }
}