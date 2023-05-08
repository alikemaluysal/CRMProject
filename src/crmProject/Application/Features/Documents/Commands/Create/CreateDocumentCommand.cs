using Application.Features.Documents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Documents.Commands.Create;

public class CreateDocumentCommand : IRequest<CreatedDocumentResponse>
{
    public int UserId { get; set; }
    public int RequestId { get; set; }
    public string DocumentFileName { get; set; }
    public int DocumentTypeId { get; set; }

    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, CreatedDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;
        private readonly DocumentBusinessRules _documentBusinessRules;

        public CreateDocumentCommandHandler(IMapper mapper, IDocumentRepository documentRepository,
                                         DocumentBusinessRules documentBusinessRules)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
            _documentBusinessRules = documentBusinessRules;
        }

        public async Task<CreatedDocumentResponse> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            Document document = _mapper.Map<Document>(request);

            await _documentRepository.AddAsync(document);

            CreatedDocumentResponse response = _mapper.Map<CreatedDocumentResponse>(document);
            return response;
        }
    }
}