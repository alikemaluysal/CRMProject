using Application.Features.Documents.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Documents.Rules;

public class DocumentBusinessRules : BaseBusinessRules
{
    private readonly IDocumentRepository _documentRepository;

    public DocumentBusinessRules(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public Task DocumentShouldExistWhenSelected(Document? document)
    {
        if (document == null)
            throw new BusinessException(DocumentsBusinessMessages.DocumentNotExists);
        return Task.CompletedTask;
    }

    public async Task DocumentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Document? document = await _documentRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DocumentShouldExistWhenSelected(document);
    }
}