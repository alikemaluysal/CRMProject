using Core.Application.Responses;

namespace Application.Features.UserEmails.Commands.Delete;

public class DeletedUserEmailResponse : IResponse
{
    public int Id { get; set; }
}