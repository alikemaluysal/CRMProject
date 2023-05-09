using Application.Features.Titles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Titles.Commands.Update;

public class UpdateTitleCommand : IRequest<UpdatedTitleResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public class UpdateTitleCommandHandler : IRequestHandler<UpdateTitleCommand, UpdatedTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;
        private readonly TitleBusinessRules _titleBusinessRules;

        public UpdateTitleCommandHandler(IMapper mapper, ITitleRepository titleRepository,
                                         TitleBusinessRules titleBusinessRules)
        {
            _mapper = mapper;
            _titleRepository = titleRepository;
            _titleBusinessRules = titleBusinessRules;
        }

        public async Task<UpdatedTitleResponse> Handle(UpdateTitleCommand request, CancellationToken cancellationToken)
        {
            Title? title = await _titleRepository.GetAsync(t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _titleBusinessRules.TitleShouldExistWhenSelected(title);
            title = _mapper.Map(request, title);

            await _titleRepository.UpdateAsync(title);

            UpdatedTitleResponse response = _mapper.Map<UpdatedTitleResponse>(title);
            return response;
        }
    }
}