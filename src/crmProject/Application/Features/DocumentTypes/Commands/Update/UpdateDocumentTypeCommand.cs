using Application.Features.DocumentTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DocumentTypes.Commands.Update;

public class UpdateDocumentTypeCommand : IRequest<UpdatedDocumentTypeResponse>
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public class UpdateDocumentTypeCommandHandler : IRequestHandler<UpdateDocumentTypeCommand, UpdatedDocumentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly DocumentTypeBusinessRules _documentTypeBusinessRules;

        public UpdateDocumentTypeCommandHandler(IMapper mapper, IDocumentTypeRepository documentTypeRepository,
                                         DocumentTypeBusinessRules documentTypeBusinessRules)
        {
            _mapper = mapper;
            _documentTypeRepository = documentTypeRepository;
            _documentTypeBusinessRules = documentTypeBusinessRules;
        }

        public async Task<UpdatedDocumentTypeResponse> Handle(UpdateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            DocumentType? documentType = await _documentTypeRepository.GetAsync(dt => dt.Id == request.Id, cancellationToken: cancellationToken);
            await _documentTypeBusinessRules.DocumentTypeShouldExistWhenSelected(documentType);

            documentType = _mapper.Map(request, documentType);

            await _documentTypeBusinessRules.DocumentTypeNameShouldNotExistWhenUpdating(documentType);

            await _documentTypeRepository.UpdateAsync(documentType);

            UpdatedDocumentTypeResponse response = _mapper.Map<UpdatedDocumentTypeResponse>(documentType);
            return response;
        }
    }
}