using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Documents.Queries.GetList;

public class GetListDocumentQuery : IRequest<GetListResponse<GetListDocumentListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDocumentQueryHandler : IRequestHandler<GetListDocumentQuery, GetListResponse<GetListDocumentListItemDto>>
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;

        public GetListDocumentQueryHandler(IDocumentRepository documentRepository, IMapper mapper)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDocumentListItemDto>> Handle(GetListDocumentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Document> documents = await _documentRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDocumentListItemDto> response = _mapper.Map<GetListResponse<GetListDocumentListItemDto>>(documents);
            return response;
        }
    }
}