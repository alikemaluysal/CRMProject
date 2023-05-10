using Application.Features.DocumentTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DocumentTypes.Commands.Create;

public class CreateDocumentTypeCommand : IRequest<CreatedDocumentTypeResponse>
{
    public string? Name { get; set; }

    public class CreateDocumentTypeCommandHandler : IRequestHandler<CreateDocumentTypeCommand, CreatedDocumentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly DocumentTypeBusinessRules _documentTypeBusinessRules;

        public CreateDocumentTypeCommandHandler(IMapper mapper, IDocumentTypeRepository documentTypeRepository,
                                         DocumentTypeBusinessRules documentTypeBusinessRules)
        {
            _mapper = mapper;
            _documentTypeRepository = documentTypeRepository;
            _documentTypeBusinessRules = documentTypeBusinessRules;
        }

        public async Task<CreatedDocumentTypeResponse> Handle(CreateDocumentTypeCommand request, CancellationToken cancellationToken)
        {

            await _documentTypeBusinessRules.DocumentTypeNameShouldNotExistWhenCreating(request.Name);
            DocumentType documentType = _mapper.Map<DocumentType>(request);

            await _documentTypeRepository.AddAsync(documentType);

            CreatedDocumentTypeResponse response = _mapper.Map<CreatedDocumentTypeResponse>(documentType);
            return response;
        }
    }
}