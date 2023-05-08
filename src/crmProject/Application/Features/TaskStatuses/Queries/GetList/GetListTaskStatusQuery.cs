using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Application.Features.TaskStatuses.Queries.GetList;

public class GetListTaskStatusQuery : IRequest<GetListResponse<GetListTaskStatusListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTaskStatusQueryHandler : IRequestHandler<GetListTaskStatusQuery, GetListResponse<GetListTaskStatusListItemDto>>
    {
        private readonly ITaskStatusRepository _taskStatusRepository;
        private readonly IMapper _mapper;

        public GetListTaskStatusQueryHandler(ITaskStatusRepository taskStatusRepository, IMapper mapper)
        {
            _taskStatusRepository = taskStatusRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTaskStatusListItemDto>> Handle(GetListTaskStatusQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TaskStatus> taskStatus = await _taskStatusRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTaskStatusListItemDto> response = _mapper.Map<GetListResponse<GetListTaskStatusListItemDto>>(taskStatus);
            return response;
        }
    }
}