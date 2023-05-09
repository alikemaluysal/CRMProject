using Application.Features.TaskStatuses.Constants;
using Application.Features.TaskStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Application.Features.TaskStatuses.Commands.Delete;

public class DeleteTaskStatusCommand : IRequest<DeletedTaskStatusResponse>
{
    public int Id { get; set; }

    public class DeleteTaskStatusCommandHandler : IRequestHandler<DeleteTaskStatusCommand, DeletedTaskStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskStatusRepository _taskStatusRepository;
        private readonly TaskStatusBusinessRules _taskStatusBusinessRules;

        public DeleteTaskStatusCommandHandler(IMapper mapper, ITaskStatusRepository taskStatusRepository,
                                         TaskStatusBusinessRules taskStatusBusinessRules)
        {
            _mapper = mapper;
            _taskStatusRepository = taskStatusRepository;
            _taskStatusBusinessRules = taskStatusBusinessRules;
        }

        public async Task<DeletedTaskStatusResponse> Handle(DeleteTaskStatusCommand request, CancellationToken cancellationToken)
        {
            TaskStatus? taskStatus = await _taskStatusRepository.GetAsync(ts => ts.Id == request.Id, cancellationToken: cancellationToken);
            await _taskStatusBusinessRules.TaskStatusShouldExistWhenSelected(taskStatus);

            await _taskStatusRepository.DeleteAsync(taskStatus!);

            DeletedTaskStatusResponse response = _mapper.Map<DeletedTaskStatusResponse>(taskStatus);
            return response;
        }
    }
}