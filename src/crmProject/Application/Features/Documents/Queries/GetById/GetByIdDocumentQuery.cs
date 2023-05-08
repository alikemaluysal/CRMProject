using Application.Features.Documents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Documents.Queries.GetById;

public class GetByIdDocumentQuery : IRequest<GetByIdDocumentResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDocumentQueryHandler : IRequestHandler<GetByIdDocumentQuery, GetByIdDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;
        private readonly DocumentBusinessRules _documentBusinessRules;

        public GetByIdDocumentQueryHandler(IMapper mapper, IDocumentRepository documentRepository, DocumentBusinessRules documentBusinessRules)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
            _documentBusinessRules = documentBusinessRules;
        }

        public async Task<GetByIdDocumentResponse> Handle(GetByIdDocumentQuery request, CancellationToken cancellationToken)
        {
            Document? document = await _documentRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _documentBusinessRules.DocumentShouldExistWhenSelected(document);

            GetByIdDocumentResponse response = _mapper.Map<GetByIdDocumentResponse>(document);
            return response;
        }
    }
}