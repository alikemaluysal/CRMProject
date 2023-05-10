using Application.Features.Genders.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Genders.Commands.Update;

public class UpdateGenderCommand : IRequest<UpdatedGenderResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateGenderCommandHandler : IRequestHandler<UpdateGenderCommand, UpdatedGenderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;
        private readonly GenderBusinessRules _genderBusinessRules;

        public UpdateGenderCommandHandler(IMapper mapper, IGenderRepository genderRepository,
                                         GenderBusinessRules genderBusinessRules)
        {
            _mapper = mapper;
            _genderRepository = genderRepository;
            _genderBusinessRules = genderBusinessRules;
        }

        public async Task<UpdatedGenderResponse> Handle(UpdateGenderCommand request, CancellationToken cancellationToken)
        {
            Gender? gender = await _genderRepository.GetAsync(g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _genderBusinessRules.GenderShouldExistWhenSelected(gender);
            await _genderBusinessRules.GenderNameShouldNotExistWhenUpdating(gender);
            gender = _mapper.Map(request, gender);



            await _genderRepository.UpdateAsync(gender);

            UpdatedGenderResponse response = _mapper.Map<UpdatedGenderResponse>(gender);
            return response;
        }
    }
}