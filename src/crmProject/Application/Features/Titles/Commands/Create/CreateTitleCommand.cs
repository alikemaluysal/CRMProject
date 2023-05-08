using Application.Features.Titles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Titles.Commands.Create;

public class CreateTitleCommand : IRequest<CreatedTitleResponse>
{
    public string Name { get; set; }

    public class CreateTitleCommandHandler : IRequestHandler<CreateTitleCommand, CreatedTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;
        private readonly TitleBusinessRules _titleBusinessRules;

        public CreateTitleCommandHandler(IMapper mapper, ITitleRepository titleRepository,
                                         TitleBusinessRules titleBusinessRules)
        {
            _mapper = mapper;
            _titleRepository = titleRepository;
            _titleBusinessRules = titleBusinessRules;
        }

        public async Task<CreatedTitleResponse> Handle(CreateTitleCommand request, CancellationToken cancellationToken)
        {
            Title title = _mapper.Map<Title>(request);

            await _titleRepository.AddAsync(title);

            CreatedTitleResponse response = _mapper.Map<CreatedTitleResponse>(title);
            return response;
        }
    }
}