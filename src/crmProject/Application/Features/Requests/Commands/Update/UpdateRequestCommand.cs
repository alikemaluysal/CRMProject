using Application.Features.Requests.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Requests.Commands.Update;

public class UpdateRequestCommand : IRequest<UpdatedRequestResponse>
{
    public Guid Id { get; set; }
    public int CustomerUserId { get; set; }
    public int EmployeeUserId { get; set; }
    public int RequestStatusId { get; set; }
    public string Description { get; set; }

    public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, UpdatedRequestResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _requestRepository;
        private readonly RequestBusinessRules _requestBusinessRules;

        public UpdateRequestCommandHandler(IMapper mapper, IRequestRepository requestRepository,
                                         RequestBusinessRules requestBusinessRules)
        {
            _mapper = mapper;
            _requestRepository = requestRepository;
            _requestBusinessRules = requestBusinessRules;
        }

        public async Task<UpdatedRequestResponse> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            Request? requestToUpdate = await _requestRepository.GetAsync(r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _requestBusinessRules.RequestShouldExistWhenSelected(requestToUpdate);
            requestToUpdate = _mapper.Map(request, requestToUpdate);

            await _requestRepository.UpdateAsync(requestToUpdate);

            UpdatedRequestResponse response = _mapper.Map<UpdatedRequestResponse>(requestToUpdate);
            return response;
        }
    }
}