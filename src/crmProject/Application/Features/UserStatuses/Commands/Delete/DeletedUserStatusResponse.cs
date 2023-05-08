using Core.Application.Responses;

namespace Application.Features.UserStatuses.Commands.Delete;

public class DeletedUserStatusResponse : IResponse
{
    public Guid Id { get; set; }
}