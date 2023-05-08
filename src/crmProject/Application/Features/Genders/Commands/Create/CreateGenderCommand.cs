using Application.Features.Genders.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Genders.Commands.Create;

public class CreateGenderCommand : IRequest<CreatedGenderResponse>
{
    public string Name { get; set; }

    public class CreateGenderCommandHandler : IRequestHandler<CreateGenderCommand, CreatedGenderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGenderRepository _genderRepository;
        private readonly GenderBusinessRules _genderBusinessRules;

        public CreateGenderCommandHandler(IMapper mapper, IGenderRepository genderRepository,
                                         GenderBusinessRules genderBusinessRules)
        {
            _mapper = mapper;
            _genderRepository = genderRepository;
            _genderBusinessRules = genderBusinessRules;
        }

        public async Task<CreatedGenderResponse> Handle(CreateGenderCommand request, CancellationToken cancellationToken)
        {
            Gender gender = _mapper.Map<Gender>(request);

            await _genderRepository.AddAsync(gender);

            CreatedGenderResponse response = _mapper.Map<CreatedGenderResponse>(gender);
            return response;
        }
    }
}