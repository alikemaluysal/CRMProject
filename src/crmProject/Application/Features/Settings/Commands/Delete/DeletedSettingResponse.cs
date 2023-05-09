using Core.Application.Responses;

namespace Application.Features.Settings.Commands.Delete;

public class DeletedSettingResponse : IResponse
{
    public int Id { get; set; }
}