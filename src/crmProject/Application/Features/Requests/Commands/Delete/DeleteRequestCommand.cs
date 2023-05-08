using Application.Features.Requests.Constants;
using Application.Features.Requests.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Requests.Commands.Delete;

public class DeleteRequestCommand : IRequest<DeletedRequestResponse>
{
    public Guid Id { get; set; }

    public class DeleteRequestCommandHandler : IRequestHandler<DeleteRequestCommand, DeletedRequestResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _requestRepository;
        private readonly RequestBusinessRules _requestBusinessRules;

        public DeleteRequestCommandHandler(IMapper mapper, IRequestRepository requestRepository,
                                         RequestBusinessRules requestBusinessRules)
        {
            _mapper = mapper;
            _requestRepository = requestRepository;
            _requestBusinessRules = requestBusinessRules;
        }

        public async Task<DeletedRequestResponse> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
        {
            Request? request = await _requestRepository.GetAsync(r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _requestBusinessRules.RequestShouldExistWhenSelected(request);

            await _requestRepository.DeleteAsync(request!);

            DeletedRequestResponse response = _mapper.Map<DeletedRequestResponse>(request);
            return response;
        }
    }
}