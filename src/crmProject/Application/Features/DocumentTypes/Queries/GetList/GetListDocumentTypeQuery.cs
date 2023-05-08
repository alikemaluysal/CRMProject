using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.DocumentTypes.Queries.GetList;

public class GetListDocumentTypeQuery : IRequest<GetListResponse<GetListDocumentTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDocumentTypeQueryHandler : IRequestHandler<GetListDocumentTypeQuery, GetListResponse<GetListDocumentTypeListItemDto>>
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IMapper _mapper;

        public GetListDocumentTypeQueryHandler(IDocumentTypeRepository documentTypeRepository, IMapper mapper)
        {
            _documentTypeRepository = documentTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDocumentTypeListItemDto>> Handle(GetListDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DocumentType> documentTypes = await _documentTypeRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDocumentTypeListItemDto> response = _mapper.Map<GetListResponse<GetListDocumentTypeListItemDto>>(documentTypes);
            return response;
        }
    }
}