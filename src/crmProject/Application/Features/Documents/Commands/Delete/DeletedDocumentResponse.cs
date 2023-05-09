using Core.Application.Responses;

namespace Application.Features.Documents.Commands.Delete;

public class DeletedDocumentResponse : IResponse
{
    public int Id { get; set; }
}