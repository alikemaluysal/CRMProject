using Application.Features.TaskEntities.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.TaskEntities.Rules;

public class TaskEntityBusinessRules : BaseBusinessRules
{
    private readonly ITaskEntityRepository _taskEntityRepository;

    public TaskEntityBusinessRules(ITaskEntityRepository taskEntityRepository)
    {
        _taskEntityRepository = taskEntityRepository;
    }

    public Task TaskEntityShouldExistWhenSelected(TaskEntity? taskEntity)
    {
        if (taskEntity == null)
            throw new BusinessException(TaskEntitiesBusinessMessages.TaskEntityNotExists);
        return Task.CompletedTask;
    }

    public async Task TaskEntityIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        TaskEntity? taskEntity = await _taskEntityRepository.GetAsync(
            predicate: te => te.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TaskEntityShouldExistWhenSelected(taskEntity);
    }
}