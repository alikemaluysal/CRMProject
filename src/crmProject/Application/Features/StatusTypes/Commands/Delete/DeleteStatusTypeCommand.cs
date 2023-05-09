using Application.Features.StatusTypes.Constants;
using Application.Features.StatusTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StatusTypes.Commands.Delete;

public class DeleteStatusTypeCommand : IRequest<DeletedStatusTypeResponse>
{
    public int Id { get; set; }

    public class DeleteStatusTypeCommandHandler : IRequestHandler<DeleteStatusTypeCommand, DeletedStatusTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStatusTypeRepository _statusTypeRepository;
        private readonly StatusTypeBusinessRules _statusTypeBusinessRules;

        public DeleteStatusTypeCommandHandler(IMapper mapper, IStatusTypeRepository statusTypeRepository,
                                         StatusTypeBusinessRules statusTypeBusinessRules)
        {
            _mapper = mapper;
            _statusTypeRepository = statusTypeRepository;
            _statusTypeBusinessRules = statusTypeBusinessRules;
        }

        public async Task<DeletedStatusTypeResponse> Handle(DeleteStatusTypeCommand request, CancellationToken cancellationToken)
        {
            StatusType? statusType = await _statusTypeRepository.GetAsync(st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _statusTypeBusinessRules.StatusTypeShouldExistWhenSelected(statusType);

            await _statusTypeRepository.DeleteAsync(statusType!);

            DeletedStatusTypeResponse response = _mapper.Map<DeletedStatusTypeResponse>(statusType);
            return response;
        }
    }
}