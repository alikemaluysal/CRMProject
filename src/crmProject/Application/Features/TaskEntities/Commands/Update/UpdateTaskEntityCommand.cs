using Application.Features.TaskEntities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TaskEntities.Commands.Update;

public class UpdateTaskEntityCommand : IRequest<UpdatedTaskEntityResponse>
{
    public Guid Id { get; set; }
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime TaskStartDate { get; set; }
    public DateTime TaskEndDate { get; set; }
    public string? Description { get; set; }
    public int TaskStatusId { get; set; }

    public class UpdateTaskEntityCommandHandler : IRequestHandler<UpdateTaskEntityCommand, UpdatedTaskEntityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskEntityRepository _taskEntityRepository;
        private readonly TaskEntityBusinessRules _taskEntityBusinessRules;

        public UpdateTaskEntityCommandHandler(IMapper mapper, ITaskEntityRepository taskEntityRepository,
                                         TaskEntityBusinessRules taskEntityBusinessRules)
        {
            _mapper = mapper;
            _taskEntityRepository = taskEntityRepository;
            _taskEntityBusinessRules = taskEntityBusinessRules;
        }

        public async Task<UpdatedTaskEntityResponse> Handle(UpdateTaskEntityCommand request, CancellationToken cancellationToken)
        {
            TaskEntity? taskEntity = await _taskEntityRepository.GetAsync(te => te.Id == request.Id, cancellationToken: cancellationToken);
            await _taskEntityBusinessRules.TaskEntityShouldExistWhenSelected(taskEntity);
            taskEntity = _mapper.Map(request, taskEntity);

            await _taskEntityRepository.UpdateAsync(taskEntity);

            UpdatedTaskEntityResponse response = _mapper.Map<UpdatedTaskEntityResponse>(taskEntity);
            return response;
        }
    }
}