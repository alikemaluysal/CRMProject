using Core.Application.Responses;

namespace Application.Features.Titles.Commands.Delete;

public class DeletedTitleResponse : IResponse
{
    public int Id { get; set; }
}