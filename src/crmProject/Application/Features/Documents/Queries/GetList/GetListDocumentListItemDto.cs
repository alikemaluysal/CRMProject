using Core.Application.Dtos;

namespace Application.Features.Documents.Queries.GetList;

public class GetListDocumentListItemDto : IDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RequestId { get; set; }
    public string DocumentFileName { get; set; }
    public int DocumentTypeId { get; set; }
}