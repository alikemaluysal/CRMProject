using Application.Features.TaskStatuses.Constants;
using Application.Features.TaskStatuses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Application.Features.TaskStatuses.Rules;

public class TaskStatusBusinessRules : BaseBusinessRules
{
    private readonly ITaskStatusRepository _taskStatusRepository;

    public TaskStatusBusinessRules(ITaskStatusRepository taskStatusRepository)
    {
        _taskStatusRepository = taskStatusRepository;
    }

    public Task TaskStatusShouldExistWhenSelected(TaskStatus? taskStatus)
    {
        if (taskStatus == null)
            throw new BusinessException(TaskStatusBusinessMessages.TaskStatusNotExists);
        return Task.CompletedTask;
    }

    public async Task TaskStatusIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        TaskStatus? taskStatus = await _taskStatusRepository.GetAsync(
            predicate: ts => ts.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TaskStatusShouldExistWhenSelected(taskStatus);
    }

    public async Task TaskStatusNameShouldNotExistWhenCreating(string name)
    {
        TaskStatus? result = await _taskStatusRepository.GetAsync(x => x.Name.ToLower() == name.ToLower());
        if (result != null)
            throw new BusinessException(TaskStatusBusinessMessages.TaskStatusNameExists);
    }

    public async Task TaskStatusNameShouldNotExistWhenUpdating(TaskStatus taskStatus)
    {
        TaskStatus? result = await _taskStatusRepository.GetAsync(x => x.Id != taskStatus.Id && x.Name.ToLower() == taskStatus.Name.ToLower());
        if (result != null)
            throw new BusinessException(TaskStatusBusinessMessages.TaskStatusNameExists);
    }
}