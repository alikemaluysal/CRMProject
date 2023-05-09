using Core.Application.Responses;

namespace Application.Features.DocumentTypes.Commands.Delete;

public class DeletedDocumentTypeResponse : IResponse
{
    public int Id { get; set; }
}