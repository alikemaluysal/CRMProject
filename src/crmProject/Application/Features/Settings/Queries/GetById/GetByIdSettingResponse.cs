using Core.Application.Responses;

namespace Application.Features.Settings.Queries.GetById;

public class GetByIdSettingResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string SettingKey { get; set; }
    public string SettingValue { get; set; }
}