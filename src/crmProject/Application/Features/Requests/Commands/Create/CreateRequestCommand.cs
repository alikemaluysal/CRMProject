using Application.Features.Requests.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Requests.Commands.Create;

public class CreateRequestCommand : IRequest<CreatedRequestResponse>
{
    public int CustomerUserId { get; set; }
    public int EmployeeUserId { get; set; }
    public int RequestStatusId { get; set; }
    public string Description { get; set; }

    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, CreatedRequestResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _requestRepository;
        private readonly RequestBusinessRules _requestBusinessRules;

        public CreateRequestCommandHandler(IMapper mapper, IRequestRepository requestRepository,
                                         RequestBusinessRules requestBusinessRules)
        {
            _mapper = mapper;
            _requestRepository = requestRepository;
            _requestBusinessRules = requestBusinessRules;
        }

        public async Task<CreatedRequestResponse> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            Request request = _mapper.Map<Request>(request);

            await _requestRepository.AddAsync(request);

            CreatedRequestResponse response = _mapper.Map<CreatedRequestResponse>(request);
            return response;
        }
    }
}