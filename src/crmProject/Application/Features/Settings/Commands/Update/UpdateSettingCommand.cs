using Application.Features.Settings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Settings.Commands.Update;

public class UpdateSettingCommand : IRequest<UpdatedSettingResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string SettingKey { get; set; }
    public string SettingValue { get; set; }

    public class UpdateSettingCommandHandler : IRequestHandler<UpdateSettingCommand, UpdatedSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISettingRepository _settingRepository;
        private readonly SettingBusinessRules _settingBusinessRules;

        public UpdateSettingCommandHandler(IMapper mapper, ISettingRepository settingRepository,
                                         SettingBusinessRules settingBusinessRules)
        {
            _mapper = mapper;
            _settingRepository = settingRepository;
            _settingBusinessRules = settingBusinessRules;
        }

        public async Task<UpdatedSettingResponse> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
        {
            Setting? setting = await _settingRepository.GetAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _settingBusinessRules.SettingShouldExistWhenSelected(setting);
            setting = _mapper.Map(request, setting);

            await _settingRepository.UpdateAsync(setting);

            UpdatedSettingResponse response = _mapper.Map<UpdatedSettingResponse>(setting);
            return response;
        }
    }
}