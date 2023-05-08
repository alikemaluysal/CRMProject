using Core.Application.Responses;

namespace Application.Features.Documents.Commands.Update;

public class UpdatedDocumentResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public int RequestId { get; set; }
    public string DocumentFileName { get; set; }
    public int DocumentTypeId { get; set; }
}