using Core.Application.Dtos;

namespace Application.Features.Settings.Queries.GetList;

public class GetListSettingListItemDto : IDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string SettingKey { get; set; }
    public string SettingValue { get; set; }
}