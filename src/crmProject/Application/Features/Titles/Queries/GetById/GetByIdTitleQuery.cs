using Application.Features.Titles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Titles.Queries.GetById;

public class GetByIdTitleQuery : IRequest<GetByIdTitleResponse>
{
    public int Id { get; set; }

    public class GetByIdTitleQueryHandler : IRequestHandler<GetByIdTitleQuery, GetByIdTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;
        private readonly TitleBusinessRules _titleBusinessRules;

        public GetByIdTitleQueryHandler(IMapper mapper, ITitleRepository titleRepository, TitleBusinessRules titleBusinessRules)
        {
            _mapper = mapper;
            _titleRepository = titleRepository;
            _titleBusinessRules = titleBusinessRules;
        }

        public async Task<GetByIdTitleResponse> Handle(GetByIdTitleQuery request, CancellationToken cancellationToken)
        {
            Title? title = await _titleRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _titleBusinessRules.TitleShouldExistWhenSelected(title);

            GetByIdTitleResponse response = _mapper.Map<GetByIdTitleResponse>(title);
            return response;
        }
    }
}