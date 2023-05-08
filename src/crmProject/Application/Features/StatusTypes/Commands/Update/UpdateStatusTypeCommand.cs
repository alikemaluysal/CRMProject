using Application.Features.StatusTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StatusTypes.Commands.Update;

public class UpdateStatusTypeCommand : IRequest<UpdatedStatusTypeResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateStatusTypeCommandHandler : IRequestHandler<UpdateStatusTypeCommand, UpdatedStatusTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStatusTypeRepository _statusTypeRepository;
        private readonly StatusTypeBusinessRules _statusTypeBusinessRules;

        public UpdateStatusTypeCommandHandler(IMapper mapper, IStatusTypeRepository statusTypeRepository,
                                         StatusTypeBusinessRules statusTypeBusinessRules)
        {
            _mapper = mapper;
            _statusTypeRepository = statusTypeRepository;
            _statusTypeBusinessRules = statusTypeBusinessRules;
        }

        public async Task<UpdatedStatusTypeResponse> Handle(UpdateStatusTypeCommand request, CancellationToken cancellationToken)
        {
            StatusType? statusType = await _statusTypeRepository.GetAsync(st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _statusTypeBusinessRules.StatusTypeShouldExistWhenSelected(statusType);
            statusType = _mapper.Map(request, statusType);

            await _statusTypeRepository.UpdateAsync(statusType);

            UpdatedStatusTypeResponse response = _mapper.Map<UpdatedStatusTypeResponse>(statusType);
            return response;
        }
    }
}