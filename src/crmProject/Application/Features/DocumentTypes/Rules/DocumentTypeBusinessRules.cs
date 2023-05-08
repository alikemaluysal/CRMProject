using Application.Features.DocumentTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.DocumentTypes.Rules;

public class DocumentTypeBusinessRules : BaseBusinessRules
{
    private readonly IDocumentTypeRepository _documentTypeRepository;

    public DocumentTypeBusinessRules(IDocumentTypeRepository documentTypeRepository)
    {
        _documentTypeRepository = documentTypeRepository;
    }

    public Task DocumentTypeShouldExistWhenSelected(DocumentType? documentType)
    {
        if (documentType == null)
            throw new BusinessException(DocumentTypesBusinessMessages.DocumentTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task DocumentTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        DocumentType? documentType = await _documentTypeRepository.GetAsync(
            predicate: dt => dt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DocumentTypeShouldExistWhenSelected(documentType);
    }
}