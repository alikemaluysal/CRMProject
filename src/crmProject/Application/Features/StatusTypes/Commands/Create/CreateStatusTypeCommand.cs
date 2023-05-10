using Application.Features.StatusTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StatusTypes.Commands.Create;

public class CreateStatusTypeCommand : IRequest<CreatedStatusTypeResponse>
{
    public string Name { get; set; }

    public class CreateStatusTypeCommandHandler : IRequestHandler<CreateStatusTypeCommand, CreatedStatusTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStatusTypeRepository _statusTypeRepository;
        private readonly StatusTypeBusinessRules _statusTypeBusinessRules;

        public CreateStatusTypeCommandHandler(IMapper mapper, IStatusTypeRepository statusTypeRepository,
                                         StatusTypeBusinessRules statusTypeBusinessRules)
        {
            _mapper = mapper;
            _statusTypeRepository = statusTypeRepository;
            _statusTypeBusinessRules = statusTypeBusinessRules;
        }

        public async Task<CreatedStatusTypeResponse> Handle(CreateStatusTypeCommand request, CancellationToken cancellationToken)
        {

            await _statusTypeBusinessRules.StatusTypeNameShouldNotExistWhenCreating(request.Name);
            StatusType statusType = _mapper.Map<StatusType>(request);

            await _statusTypeRepository.AddAsync(statusType);

            CreatedStatusTypeResponse response = _mapper.Map<CreatedStatusTypeResponse>(statusType);
            return response;
        }
    }
}