using Application.Features.DocumentTypes.Constants;
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

    public async Task DocumentTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        DocumentType? documentType = await _documentTypeRepository.GetAsync(
            predicate: dt => dt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DocumentTypeShouldExistWhenSelected(documentType);
    }

    public async Task DocumentTypeNameCanNotBeDuplicatedWhenInserted(string name)
    {
        DocumentType? result = await _documentTypeRepository.GetAsync(x => x.Name.ToLower() == name.ToLower());
        if (result != null)
            throw new BusinessException(DocumentTypesBusinessMessages.DocumentTypeNameExists);
    }

    public async Task DocumentTypeNameCanNotBeDuplicatedWhenUpdated(DocumentType documentType)
    {
        DocumentType? result = await _documentTypeRepository.GetAsync(x => x.Id != documentType.Id && x.Name.ToLower() == documentType.Name.ToLower());
        if (result != null)
            throw new BusinessException(DocumentTypesBusinessMessages.DocumentTypeNameExists);
    }
}