using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserEmails.Queries.GetList;

public class GetListUserEmailQuery : IRequest<GetListResponse<GetListUserEmailListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserEmailQueryHandler : IRequestHandler<GetListUserEmailQuery, GetListResponse<GetListUserEmailListItemDto>>
    {
        private readonly IUserEmailRepository _userEmailRepository;
        private readonly IMapper _mapper;

        public GetListUserEmailQueryHandler(IUserEmailRepository userEmailRepository, IMapper mapper)
        {
            _userEmailRepository = userEmailRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserEmailListItemDto>> Handle(GetListUserEmailQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserEmail> userEmails = await _userEmailRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserEmailListItemDto> response = _mapper.Map<GetListResponse<GetListUserEmailListItemDto>>(userEmails);
            return response;
        }
    }
}