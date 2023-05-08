using Application.Features.Settings.Constants;
using Application.Features.Settings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Settings.Commands.Delete;

public class DeleteSettingCommand : IRequest<DeletedSettingResponse>
{
    public Guid Id { get; set; }

    public class DeleteSettingCommandHandler : IRequestHandler<DeleteSettingCommand, DeletedSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISettingRepository _settingRepository;
        private readonly SettingBusinessRules _settingBusinessRules;

        public DeleteSettingCommandHandler(IMapper mapper, ISettingRepository settingRepository,
                                         SettingBusinessRules settingBusinessRules)
        {
            _mapper = mapper;
            _settingRepository = settingRepository;
            _settingBusinessRules = settingBusinessRules;
        }

        public async Task<DeletedSettingResponse> Handle(DeleteSettingCommand request, CancellationToken cancellationToken)
        {
            Setting? setting = await _settingRepository.GetAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _settingBusinessRules.SettingShouldExistWhenSelected(setting);

            await _settingRepository.DeleteAsync(setting!);

            DeletedSettingResponse response = _mapper.Map<DeletedSettingResponse>(setting);
            return response;
        }
    }
}