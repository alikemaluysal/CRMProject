using Core.Application.Responses;

namespace Application.Features.Documents.Queries.GetById;

public class GetByIdDocumentResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RequestId { get; set; }
    public string DocumentFileName { get; set; }
    public int DocumentTypeId { get; set; }
}