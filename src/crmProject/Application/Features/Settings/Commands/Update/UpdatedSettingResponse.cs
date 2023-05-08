using Core.Application.Responses;

namespace Application.Features.Settings.Commands.Update;

public class UpdatedSettingResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string SettingKey { get; set; }
    public string SettingValue { get; set; }
}