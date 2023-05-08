using Application.Features.TaskEntities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TaskEntities.Commands.Create;

public class CreateTaskEntityCommand : IRequest<CreatedTaskEntityResponse>
{
    public int RequestId { get; set; }
    public int EmployeeUserId { get; set; }
    public DateTime TaskStartDate { get; set; }
    public DateTime TaskEndDate { get; set; }
    public string? Description { get; set; }
    public int TaskStatusId { get; set; }

    public class CreateTaskEntityCommandHandler : IRequestHandler<CreateTaskEntityCommand, CreatedTaskEntityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskEntityRepository _taskEntityRepository;
        private readonly TaskEntityBusinessRules _taskEntityBusinessRules;

        public CreateTaskEntityCommandHandler(IMapper mapper, ITaskEntityRepository taskEntityRepository,
                                         TaskEntityBusinessRules taskEntityBusinessRules)
        {
            _mapper = mapper;
            _taskEntityRepository = taskEntityRepository;
            _taskEntityBusinessRules = taskEntityBusinessRules;
        }

        public async Task<CreatedTaskEntityResponse> Handle(CreateTaskEntityCommand request, CancellationToken cancellationToken)
        {
            TaskEntity taskEntity = _mapper.Map<TaskEntity>(request);

            await _taskEntityRepository.AddAsync(taskEntity);

            CreatedTaskEntityResponse response = _mapper.Map<CreatedTaskEntityResponse>(taskEntity);
            return response;
        }
    }
}