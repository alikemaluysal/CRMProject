using Application.Features.Settings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Settings.Commands.Create;

public class CreateSettingCommand : IRequest<CreatedSettingResponse>
{
    public int UserId { get; set; }
    public string SettingKey { get; set; }
    public string SettingValue { get; set; }

    public class CreateSettingCommandHandler : IRequestHandler<CreateSettingCommand, CreatedSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISettingRepository _settingRepository;
        private readonly SettingBusinessRules _settingBusinessRules;

        public CreateSettingCommandHandler(IMapper mapper, ISettingRepository settingRepository,
                                         SettingBusinessRules settingBusinessRules)
        {
            _mapper = mapper;
            _settingRepository = settingRepository;
            _settingBusinessRules = settingBusinessRules;
        }

        public async Task<CreatedSettingResponse> Handle(CreateSettingCommand request, CancellationToken cancellationToken)
        {
            Setting setting = _mapper.Map<Setting>(request);

            await _settingRepository.AddAsync(setting);

            CreatedSettingResponse response = _mapper.Map<CreatedSettingResponse>(setting);
            return response;
        }
    }
}