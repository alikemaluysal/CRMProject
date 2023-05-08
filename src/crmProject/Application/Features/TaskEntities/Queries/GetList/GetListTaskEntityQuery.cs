using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.TaskEntities.Queries.GetList;

public class GetListTaskEntityQuery : IRequest<GetListResponse<GetListTaskEntityListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTaskEntityQueryHandler : IRequestHandler<GetListTaskEntityQuery, GetListResponse<GetListTaskEntityListItemDto>>
    {
        private readonly ITaskEntityRepository _taskEntityRepository;
        private readonly IMapper _mapper;

        public GetListTaskEntityQueryHandler(ITaskEntityRepository taskEntityRepository, IMapper mapper)
        {
            _taskEntityRepository = taskEntityRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTaskEntityListItemDto>> Handle(GetListTaskEntityQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TaskEntity> taskEntities = await _taskEntityRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTaskEntityListItemDto> response = _mapper.Map<GetListResponse<GetListTaskEntityListItemDto>>(taskEntities);
            return response;
        }
    }
}