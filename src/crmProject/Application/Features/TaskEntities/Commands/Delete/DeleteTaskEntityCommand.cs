using Application.Features.TaskEntities.Constants;
using Application.Features.TaskEntities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TaskEntities.Commands.Delete;

public class DeleteTaskEntityCommand : IRequest<DeletedTaskEntityResponse>
{
    public int Id { get; set; }

    public class DeleteTaskEntityCommandHandler : IRequestHandler<DeleteTaskEntityCommand, DeletedTaskEntityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskEntityRepository _taskEntityRepository;
        private readonly TaskEntityBusinessRules _taskEntityBusinessRules;

        public DeleteTaskEntityCommandHandler(IMapper mapper, ITaskEntityRepository taskEntityRepository,
                                         TaskEntityBusinessRules taskEntityBusinessRules)
        {
            _mapper = mapper;
            _taskEntityRepository = taskEntityRepository;
            _taskEntityBusinessRules = taskEntityBusinessRules;
        }

        public async Task<DeletedTaskEntityResponse> Handle(DeleteTaskEntityCommand request, CancellationToken cancellationToken)
        {
            TaskEntity? taskEntity = await _taskEntityRepository.GetAsync(te => te.Id == request.Id, cancellationToken: cancellationToken);
            await _taskEntityBusinessRules.TaskEntityShouldExistWhenSelected(taskEntity);

            await _taskEntityRepository.DeleteAsync(taskEntity!);

            DeletedTaskEntityResponse response = _mapper.Map<DeletedTaskEntityResponse>(taskEntity);
            return response;
        }
    }
}